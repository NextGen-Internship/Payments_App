using System;
using System.Threading.Tasks;

namespace QArte.Services.ServiceInterfaces
{
	public interface ICheckExistingService
	{
        Task<bool> UserExists(int id, string username, string password);
        Task<bool> BankAccountExists(int id, string IBAN);
        Task<bool> PageExists(int id, string QR_Link);
        Task<bool> InvoiceExists(int id);
    }
}

