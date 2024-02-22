using System;
using Quartz;
using QArte.Services.ServiceInterfaces;
using QArte.Services.Services;
using QArte.Services.DTOs;
using System.Net;
using System.Net.Mail;
using QArte.Persistance.Enums;


namespace QArte.Services.Services.quartzPayouts
{
	public class PayoutSchedulerService : IJob
	{
		IStripeService _stripeService;
        IUserService _userService;

        public PayoutSchedulerService(IStripeService stripeService, IUserService userService)
        {
            _stripeService = stripeService;
            _userService = userService;
        }

        private void sendEmail(UserDTO connectUser, long amount, string currency)
        {
            string senderEmail = "qartemail@gmail.com";
            string senderPassword = "rsbg uiet knzh kess";

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(senderEmail);
            mail.To.Add(connectUser.Email);
            mail.Subject = "QArté payout succeeded";
            mail.Body = $"Transaction of {(double)amount / 100} {currency.ToUpper()} \n" +
                $"has been successfuly payed out to {connectUser.FirstName} {connectUser.LastName}\n \n" +
                $"From QArté team";

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }

        private async Task<bool> HandlePayouts(string settlementCycle)
        {

            var usersForPayout = await _userService.GetBySettlementCycle(settlementCycle);

            foreach(UserDTO user in usersForPayout)
            {
                try
                {
                    var payout = await _stripeService.CreatePayoutAsync(user);

                    if (payout == null)
                        continue;

                    sendEmail(user, payout.Amount, payout.Currency);
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

            return true;

        }

        public async Task Execute(IJobExecutionContext context)
        {

            await HandlePayouts("Daily");

            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                await HandlePayouts("Weekly");
            }

            if (DateTime.Now.Day == 1)
            {
                await HandlePayouts("Monthly");
            }
        }

    }
}

