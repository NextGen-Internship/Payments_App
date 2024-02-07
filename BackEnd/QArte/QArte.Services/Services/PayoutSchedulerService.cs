using System;
using Coravel;
using Coravel.Scheduling;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Coravel.Scheduling.Schedule;
using Coravel.Invocable;

namespace QArte.Services.Services
{
    public class PayoutSchedulerService : IInvocable
    {
        private readonly UserService _userService;
        private readonly InvoiceService _invoiceService;
        private readonly BankAccountService _bankAccountService;

        public PayoutSchedulerService(UserService userService, InvoiceService invoiceService, BankAccountService bankAccountService)
        {
            _userService = userService;
            _invoiceService = invoiceService;
            _bankAccountService = bankAccountService;
        }


        private void HandleMonday()
        {
            
        }

        private void HandleFirstDayOfMonth()
        {
            throw new NotImplementedException();
        }

        public Task Invoke()
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                HandleMonday();
            }
            if (DateTime.Now.Day == 1)
            {
                HandleFirstDayOfMonth();
            }

            return Task.CompletedTask;
        }


    }
}

