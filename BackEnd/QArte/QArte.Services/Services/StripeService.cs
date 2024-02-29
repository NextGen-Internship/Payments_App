using Stripe;
using Stripe.Checkout;
using QArte.Services.ServiceInterfaces;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;


namespace QArte.Services.Services
{
	public class StripeService : IStripeService
	{

        public StripeService()
        {
        }

        public async Task<string> CreateSubAccountAsync(User user, BankAccountDTO bankAccount)
        {

            var accountService = new AccountService();

            var account = await accountService.CreateAsync(new AccountCreateOptions
            {
                Type = "custom",
                Country = user.Country,
                Email = user.Email,
                BusinessType = "individual",


                Capabilities = new AccountCapabilitiesOptions
                {
                    CardPayments = new AccountCapabilitiesCardPaymentsOptions
                    {
                        Requested = true,
                    },
                    Transfers = new AccountCapabilitiesTransfersOptions
                    {
                        Requested = true
                    },
                },
                Individual = new AccountIndividualOptions
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = new AddressOptions
                    {
                        Line1 = user.address,
                        City = user.City,
                        PostalCode = user.PostalCode,
                        Country = user.Country
                    },
                    Dob = new DobOptions
                    {
                        Day = 1,
                        Month = 1,
                        Year = 1990,
                    },
                    Phone = user.PhoneNumber,
                    Email = user.Email,

                },

                TosAcceptance = new AccountTosAcceptanceOptions
                {
                    Date = DateTime.UtcNow,
                    Ip = "1.1.1.1",
                },
                ExternalAccount = new AccountBankAccountOptions
                {
                    AccountNumber = bankAccount.IBAN,
                    Country = user.Country,
                    Currency = "bgn",
                    AccountHolderType = "individual",
                },
                BusinessProfile = new AccountBusinessProfileOptions
                {
                    ProductDescription = "Street art",
                    Mcc = "5971"
                },

                Settings = new AccountSettingsOptions
                {
                    Payouts = new AccountSettingsPayoutsOptions
                    {
                        Schedule = new AccountSettingsPayoutsScheduleOptions
                        {
                           Interval = "manual",
                        }

                    }
                }
            });
            
            return account.Id;
        }

        public async Task<Session> CreateCheckoutSession(SuccCancelUrlDTO urls)
        {

            var options = new SessionCreateOptions()
            {
                LineItems = new List<SessionLineItemOptions>()
               {
                   new SessionLineItemOptions()
                   {
                       Price = "price_1OoLSQHDcTx887mGRsl4MVnZ",
                       Quantity = 1,
                   }
               },
                PaymentMethodTypes = new List<string>()
                {
                    "card",
                },
                Metadata = new Dictionary<string, string>
                {
                    { "userID", urls.UserID.ToString() }
                },
                Mode = "payment",
                SuccessUrl = urls.SuccessURL,
                CancelUrl = urls.CancelURL
            };
            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            return session;
        }

        public void DeleteSubAccount(User user)
        {
            var service = new AccountService();


            var result = service.Delete(user.StripeAccountID);
            if (result.Deleted == true)
            {
                return;
            }

        }

        public async Task<Transfer> CreateTansferAsync(UserDTO user, long amount, string currency)
        {

            var options = new TransferCreateOptions
            {
                Amount = amount,
                Currency = currency,
                Destination = user.StripeAccountID,
                Description = "Money payed after fee",
                TransferGroup = "QArté",
                
            };

            var service = new TransferService();


            return await service.CreateAsync(options);

        }

        private async Task<Balance> GetAccountBalanceAsync(UserDTO user)
        {
            var balanceOptions = new BalanceGetOptions();
            var requestOptions = new RequestOptions
            {
                StripeAccount = user.StripeAccountID,
            };

            var balanceService = new BalanceService();

            return await balanceService.GetAsync(balanceOptions, requestOptions);
        }

        public async Task<Payout> CreatePayoutAsync(UserDTO user)
        {

            Balance balance = await GetAccountBalanceAsync(user);

            var balanceInCurrency = balance.Available.FirstOrDefault(b => b.Currency == "bgn");

            if (balanceInCurrency == null)
            {
                throw new InvalidOperationException($"Balance not available in BGN");
            }

            if(balanceInCurrency.Amount == 0)
            {
                return null;
            }

            var options = new PayoutCreateOptions
            {
                Amount = balanceInCurrency.Amount,
                Currency = "bgn",
            };

            var service = new PayoutService();


            var payout = await service.CreateAsync(options, new RequestOptions
            {
                StripeAccount = user.StripeAccountID,
            });

            return payout;


        }

    }
}

