﻿using Stripe;
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

        private string getPayoutInterval(User user)
        {

            switch (user.SettlementCycle.SettlementCycles)
            {
                case Persistance.Enums.ESettlementCycles.Daily:
                    return "daily";
                case Persistance.Enums.ESettlementCycles.Weekly:
                    return "weekly";
                case Persistance.Enums.ESettlementCycles.Monthly:
                    return "monthly";
                default:
                    throw new ArgumentException("Invalid settlement cycle specified.");
            }
        }

        public async Task<string> CreateSubAccountAsync(User user, BankAccountDTO bankAccount)
        {
            string payoutInterval = getPayoutInterval(user);

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
                            Interval = payoutInterval,
                            WeeklyAnchor = payoutInterval == "weekly" ? "monday" : null,
                            MonthlyAnchor = payoutInterval == "monthly" ? 1 : null,
                        }

                    }
                }
            });
            
            return account.Id;
        }

        public async Task<Session> CreateCheckoutSession(string successUrl, string cancelUrl, string accountID)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "bgn",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Donation"
                            },
                            UnitAmount = 0,
                        },
                        Quantity = 1
                    },
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    TransferGroup = accountID
                },
            };

            var service = new SessionService();
            
            return await service.CreateAsync(options);
            
        }

        public void DeleteSubAccount(User user)
        {
            var service = new AccountService();

            try
            {
                var result = service.Delete(user.StripeAccountID);
                if (result.Deleted == true)
                {
                    return;
                }
            }
            catch
            {
            }

        }

        public async Task<Transfer> CreateTansferAsync(UserDTO user, long amount, string currency)
        {

            var balanceService = new BalanceService();
            var balance = balanceService.Get();


            var options = new TransferCreateOptions
            {
                Amount = amount,
                Currency = currency,
                Destination = user.StripeAccountID,
                Description = "Settlement cycle transfer",
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

