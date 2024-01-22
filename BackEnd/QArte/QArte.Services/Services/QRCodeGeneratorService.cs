using System;
//using QRCoder;
using System.IO;
using QArte.Services.ServiceInterfaces;
using System.Drawing;
using Spire.Barcode;

namespace QArte.Services.Services
{
    public class QRCodeGeneratorService : IQRCodeGeneratorService
    {


        public QRCodeGeneratorService()
        {

        }

        public string CreateQRCode(string URL)
        {
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/User1";
            string name = "QR1.png";
            string path = location + name;
            Bitmap logo = new Bitmap("/Users/Martin.Kolev/M_Kolev/QArte/BackEnd/QArte");

            BarcodeSettings settings = new BarcodeSettings();

            settings.Type = BarCodeType.QRCode;
            settings.QRCodeECL = QRCodeECL.M;
            settings.ShowText = false;
            settings.X = 2.5f;
            string data = URL;
            settings.Data = data;
            settings.Data2D = data;

            settings.QRCodeLogoImage = Image.FromFile("/Users/Martin.Kolev/M_Kolev/QArte/BackEnd/QArte.png");
            BarCodeGenerator barCodeGenerator = new BarCodeGenerator(settings);
            Image image = barCodeGenerator.GenerateImage();
            image.Save("User1_Page1.png",System.Drawing.Imaging.ImageFormat.Png);

            return path;
            /*
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData Data = qRCodeGenerator.CreateQrCode(URL, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode pngByteQRCode = new PngByteQRCode(Data);
            byte[] qrAsByte = pngByteQRCode.GetGraphic(20);
            */
            //Image image = Image.FromStream(new MemoryStream(qrAsByte));
            /*
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/User1";
            string name = "QR1.png";
            string path = location + name;

            image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            

            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 300,
                Height = 300,
                Margin = 0,
                PureBarcode = false
            };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            BarcodeWriter writer = new()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = encodingOptions
            };

            Bitmap bitmap = writer.Write(URL);
            Bitmap logo = new Bitmap("/Users/Martin.Kolev/M_Kolev/QArte/BackEnd/QArte");
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(logo, new Point((bitmap.Width-logo.Width)/2,(bitmap.Height-logo.Height)/2);


            return location;
            */

        }

        public Task<string> DeleteQRCode(int UserID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetQRCode(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}

