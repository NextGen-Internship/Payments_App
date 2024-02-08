using System;
using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;
using Amazon.S3;
using Amazon;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace QArte.Services.Services
{
    public class PictureService : IPictureService
    {
        //make it so it works with the amazon!
        private readonly QArteDBContext _qArteDBContext;
        private readonly AmazonData _amazonData;


        public PictureService(QArteDBContext qArteDBContext, AmazonData amazonData)
        {
            _qArteDBContext = qArteDBContext;
            _amazonData = amazonData;
        }

        public async Task<PictureDTO> DeleteAsync(int id)
        {
            //Make it so it get deleted from the amazon

            var picture = await _qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");


            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            await client.DeleteObjectAsync(_amazonData.BucketName, picture.PictureURL);


            _qArteDBContext.Pictures.Remove(picture);
            await _qArteDBContext.SaveChangesAsync();

            return picture.GetDTO();
        }

        public async Task<IEnumerable<PictureDTO>> GetAsync()
        {
            return await this._qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .Select(x => new PictureDTO
                {
                    ID = x.ID,
                    PictureURL = x.PictureURL,
                    GalleryID = x.GalleryID
                }).ToListAsync();
        }

        public async Task<PictureDTO> GetPictureByID(int id)
        {
            var picture = await _qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return picture.GetDTO();
        }

        public async Task<PictureDTO> GetPicturesByGalleryID(int id)
        {
            var picture = await _qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .FirstOrDefaultAsync(x => x.GalleryID == id)
                ?? throw new ApplicationException("Not found");

            return picture.GetDTO();

        }

        public async Task<PictureDTO> PostAsync(PictureDTO obj)
        {
            //Make it so it gets uploaded to the amazon

            PictureDTO result = null;

            var deletedPicture = await _qArteDBContext.Pictures
                                            .Include(x => x.Gallery)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.GalleryID == obj.GalleryID && x.PictureURL == obj.PictureURL);

            var newPicture = obj.GetEntity();

            if (deletedPicture == null)
            {
                await _qArteDBContext.Pictures.AddAsync(newPicture);
                await _qArteDBContext.SaveChangesAsync();
                result = newPicture.GetDTO();
            }
            else
            {
                result = deletedPicture.GetDTO();
            }
            return result;
        }

        public async Task<PictureDTO> UpdateAsync(int id, PictureDTO obj)
        {
            var Picture = await _qArteDBContext.Pictures
                                .Include(x => x.Gallery)
                                .FirstOrDefaultAsync(x => x.ID == id)
                                ?? throw new ApplicationException("Not found");

            if (obj.PictureURL == null)
            {
                throw new ApplicationException("Bad input");
            }

            //var region = RegionEndpoint.EUCentral1;
            //AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            //bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, _amazonData.BucketName);
            //if (!bucketExists)
            //{
            //    PutBucketRequest bucketRequest = new PutBucketRequest()
            //    {
            //        BucketName = _amazonData.BucketName,
            //        UseClientRegion = true
            //    };
            //    await client.PutBucketAsync(bucketRequest);
            //}
            //PutObjectRequest objectRequest = new PutObjectRequest()
            //{
            //    BucketName = _amazonData.BucketName,
            //    Key = Picture.PictureURL,
            //    InputStream = data.AsStream()
            //};
            //await client.PutObjectAsync(objectRequest);

            Picture.ID = obj.ID;
            Picture.PictureURL = obj.PictureURL;
            await _qArteDBContext.SaveChangesAsync();

            return Picture.GetDTO();
        }
    }
}