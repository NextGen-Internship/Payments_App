using System;
using System.IO;
using QArte.Services.ServiceInterfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using System.Drawing.Drawing2D;
using SkiaSharp.QrCode;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Amazon;
using System.Net;
using System.Net.Mail;

namespace QArte.Services.Services
{
    public class QRCodeGeneratorService : IQRCodeGeneratorService
    {

        //private readonly AmazonData _amazonData;
        //public QRCodeGeneratorService(AmazonData amazonData)
        //{
        //    _amazonData = amazonData;
        //}

        public string CreateQRCode(string URL, string pageID, string userID)
        {
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/"+userID+"/";
            string path = location + pageID;
            string qrPath = path + "/" + "QR.png";
            string logoPath = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/QArte_B.png";


            if (!Directory.Exists(path))
            {
                DirectoryInfo directory = Directory.CreateDirectory(path);
            }

            SkiaSharp.SKBitmap sKBitmap = SkiaSharp.SKBitmap.Decode(logoPath);
            SkiaSharp.SKImage logo = SkiaSharp.SKImage.FromBitmap(sKBitmap);

            using var generator = new QRCodeGenerator();
            var qr = generator.CreateQrCode(URL, ECCLevel.H);

            var info = new SkiaSharp.SKImageInfo(512, 512);
            using var surfice = SkiaSharp.SKSurface.Create(info);

            var canvas = surfice.Canvas;
            canvas.Render(qr, SkiaSharp.SKRect.Create(512f, 512f), SkiaSharp.SKColors.White, SkiaSharp.SKColors.Black);

            SkiaSharp.SKPaint paint = new SkiaSharp.SKPaint
            {
                Color = SkiaSharp.SKColors.White,
                IsAntialias = true,
            };
            canvas.DrawRect(new SkiaSharp.SKRect(210, 210, 210 + 100, 210 + 113), paint);


            canvas.DrawImage(logo, 210, 210);

            using var image = surfice.Snapshot();
            using var data = image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100);
            using var stream = File.OpenWrite(qrPath);
            data.SaveTo(stream);
            SendMail(qrPath);

            return path;

        }

        public void SendMail(string image)
        {
            //send the image to mail
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("martin.kolev.dev@gmail.com");
            mail.To.Add("martin.kolev.dev@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "mail with attachment";

            Attachment attachment;
            attachment = new Attachment(image);
            mail.Attachments.Add(attachment);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("martin.kolev.dev@gmail.com","AnIv1AI5O7!");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);

        }


        public string DeleteQRCode(string pageID,string userID)
        {
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/" + userID + "/";
            string path = location + pageID;
            string qrPath = path + "/" + "QR.png";

            DirectoryInfo directory = new DirectoryInfo(path);

            foreach(FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            directory.Delete();


            return path;
        }

        public IEnumerable<string> GetAll(string userID)
        {
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/" + userID + "/";
            DirectoryInfo directory = new DirectoryInfo(location);

            List<string> paths = new List<string>();

            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (file.Name == "QR.png")
                    {
                        paths.Append(file.DirectoryName);
                    }
                }

            }

            return paths;
        }

        public string GetQRCode(string pageID, string userID)
        {
            string location = "/Users/Martin.Kolev/M_Kolev/QArte/Pictures/Users/" + userID + "/";
            string path = location + pageID;
            string qrPath = path + "/" + "QR.png";
            return qrPath;
        }
    }
}

