using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
    public interface IPaymentMethodsService : ICRUDshared<PaymentMethodDTO>
    {
        Task<PaymentMethodDTO> GetPaymentMethodByID(int id);
        Task<PaymentMethodDTO> GetPaymentMethodByUserID(int id);
    }
}