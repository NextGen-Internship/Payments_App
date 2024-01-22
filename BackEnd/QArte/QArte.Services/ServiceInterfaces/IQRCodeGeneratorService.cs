using System;


namespace QArte.Services.ServiceInterfaces
{
    public interface IQRCodeGeneratorService
    {
        Task<string> DeleteQRCode(int UserID);
        string CreateQRCode(string URL);
        Task<IEnumerable<string>> GetAll();
        Task<string> GetQRCode(int UserID);
    }
}

