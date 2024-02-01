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
        Task<Session> CreateCheckoutSession(string successUrl, string cancelUrl, string accountID);
        Task<Transfer> CreateTansferAsync(UserDTO user, int amount, string currency);
    }
}
