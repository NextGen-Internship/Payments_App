using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;

namespace QArte.Services.Services
{
	public class PaymentMethodService : IPaymentMethodsService
	{
		public PaymentMethodService()
		{
		}

        public Task<PaymentMethodDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentMethodDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodDTO> GetPaymentMethodByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodDTO> GetPaymentMethodByPaymentType(EPaymentMethods ePaymentMethod)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodDTO> GetPaymentMethodByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodDTO> PostAsync(PaymentMethodDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodDTO> UpdateAsync(int id, PaymentMethodDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

