using QArte.Services.ServiceInterfaces;
using SkiaSharp.QrCode;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon;
using Amazon.S3.Util;
using System.Net;
using System.Net.Mail;

namespace QArte.Services.Services
{
    public class QRCodeGeneratorService : IQRCodeGeneratorService
    {

        private readonly IAmazonData _amazonData;

        public QRCodeGeneratorService(IAmazonData amazonData)
        {
            _amazonData = amazonData;
        }

        public async void CreateQRCode(string URL, string galleryID, string userID, string userEmail)
        {
            string logoPath = "Public_Resources/QArte_B.jpg";
            string dummy = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_QR.png";

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, _amazonData.BucketName);

            GetObjectRequest getObjectRequest = new GetObjectRequest
            {
                BucketName = _amazonData.BucketName,
                Key = logoPath
            };
            using var response = await client.GetObjectAsync(getObjectRequest);
            using var stream = response.ResponseStream;

            SkiaSharp.SKBitmap sKBitmap = SkiaSharp.SKBitmap.Decode(stream);
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
            canvas.DrawRect(new SkiaSharp.SKRect(210, 250, 210 + 100, 210 + 113), paint);


            canvas.DrawImage(logo, 210, 210);

            using var image = surfice.Snapshot();
            using var data = image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100);

            if (!bucketExists)
            {
                PutBucketRequest bucketRequest = new PutBucketRequest()
                {
                    BucketName = _amazonData.BucketName,
                    UseClientRegion = true
                };
                await client.PutBucketAsync(bucketRequest);
            }
            PutObjectRequest objectRequest = new PutObjectRequest()
            {
                BucketName = _amazonData.BucketName,
                Key = dummy,
                InputStream = data.AsStream()
            };
            await client.PutObjectAsync(objectRequest);

            SendMail(dummy, userEmail, client);

        }

        public async void SendMail(string image, string userEmail, AmazonS3Client client)
        {
            string senderEmail = "qartemail@gmail.com";
            string senderPassword = "rsbg uiet knzh kess";
            string recipientEmail = userEmail;
            string imageFilePath = image;

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = "QArtè QR code for you page";
            mail.Body = "Thank you for using QArtè! Here's you QR code";

            GetObjectRequest getObjectRequest = new GetObjectRequest
            {
                BucketName = _amazonData.BucketName,
                Key = imageFilePath
            };
            using var response = await client.GetObjectAsync(getObjectRequest);
            using var stream = response.ResponseStream;

            Attachment attachment = new Attachment(stream,"QRCode.png");
            mail.Attachments.Add(attachment);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;
    
            smtpClient.Send(mail);


        }


        public async void DeleteQRCode(string galleryID, string userID)
        {

            string dummy = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_QR.png";


            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            await client.DeleteObjectAsync(_amazonData.BucketName, dummy);

        }

        public async void TotalDeleteQRCode(string galleryID, string userID)
        {

            string dummy = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_QR.png";


            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            await client.DeleteObjectAsync(_amazonData.BucketName, dummy);
        }

        public void GetQRCode(string galleryID, string userID, string userEmail)
        {
            string qrPath = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_QR.png";

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);


            SendMail(qrPath, userEmail, client);
        }
    }
}

