using System;


namespace QArte.Services.ServiceInterfaces
{
    public interface IQRCodeGeneratorService
    {
        string DeleteQRCode(string pageID, string userID);
        void CreateQRCode(string URL, string pageID, string userID);
        IEnumerable<string> GetAll(string userID);
        string GetQRCode(string pageID, string userID);
    }
}

