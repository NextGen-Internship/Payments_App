using System;
using Stripe;
using Stripe.Checkout;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.ServiceInterfaces
{
    public interface IStripeService
    {
        void DeleteSubAccount(User user);
        Task<string> CreateSubAccountAsync(User user, BankAccountDTO bankAccount);
        Task<Session> CreateCheckoutSession(SuccCancelUrlDTO urls);
        Task<Transfer> CreateTansferAsync(UserDTO user, long amount, string currency);
        Task<Payout> CreatePayoutAsync(UserDTO user);
    }
}
