using System;


namespace QArte.Services.ServiceInterfaces
{
    public interface IQRCodeGeneratorService
    {
        string DeleteQRCode(string pageID, string userID);
        string CreateQRCode(string URL, string pageID, string userID);
        IEnumerable<string> GetAll();
        string GetQRCode(int pageID);
    }
}

