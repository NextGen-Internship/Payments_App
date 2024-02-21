using System;


namespace QArte.Services.ServiceInterfaces
{
    public interface IQRCodeGeneratorService
    {
        void DeleteQRCode(string pageID, string userID);
        void TotalDeleteQRCode(string pageID, string userID);
        void CreateQRCode(string URL, string pageID, string userID, string userEmail);
        void GetQRCode(string galleryID, string userID,string userEmail);
    }
}

