using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance;
using QArte.Persistance.PersistanceModels;
using Amazon.S3;
using Amazon;
using Amazon.S3.Model;
using Amazon.S3.Util;
using QArte.Persistance.Helpers;

namespace QArte.Services.Services
{
    public class PictureService : IPictureService
    {
        private readonly QArteDBContext _qArteDBContext;
        private readonly IAmazonData _amazonData;


        public PictureService(QArteDBContext qArteDBContext, IAmazonData amazonData)
        {
            _qArteDBContext = qArteDBContext;
            _amazonData = amazonData;
        }

        public async Task<PictureDTO> DeleteAsync(int id)
        {

            var picture = await _qArteDBContext.Pictures
                .FirstOrDefaultAsync(x => x.ID == id);

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            await client.DeleteObjectAsync(_amazonData.BucketName, picture.PictureURL);

            _qArteDBContext.Pictures.Remove(picture);
            await _qArteDBContext.SaveChangesAsync();

            return picture.GetDTO();
        }

        public async Task<IEnumerable<PictureDTO>> GetAsync()
        {
            
            var picList = await this._qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .Select(x => new PictureDTO
                {
                    ID = x.ID,
                    PictureURL = x.PictureURL,
                    GalleryID = x.GalleryID
                }).ToListAsync();
            if (picList.Count == 0) { return picList;}


            var user = await _qArteDBContext.Pages.FirstOrDefaultAsync(x => x.GalleryID == picList[0].GalleryID);

            string path = $"Users\\/{user.UserID.ToString()}\\/{picList[0].GalleryID.ToString()}\\/";

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);

            foreach(PictureDTO pictureDTO in picList)
            {
                GetObjectRequest getObjectRequest = new GetObjectRequest
                {
                    BucketName = _amazonData.BucketName,
                    Key = pictureDTO.PictureURL
                };
                using var response = await client.GetObjectAsync(getObjectRequest);
                using var stream = response.ResponseStream;
                pictureDTO.PictureURL = stream.ToString();
                if (pictureDTO.PictureURL.Contains(".jpg"))
                {
                    pictureDTO.isImage = true;
                }
                else
                {
                    pictureDTO.isImage = false;
                }
            }

            return picList;

        }

        public async Task<PictureDTO> GetPictureByID(int id)
        {
            var picture = await _qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            GetObjectRequest getObjectRequest = new GetObjectRequest
            {
                BucketName = _amazonData.BucketName,
                Key = picture.PictureURL
            };
            using var response = await client.GetObjectAsync(getObjectRequest);
            using var stream = response.ResponseStream;
            PictureDTO pictureDTO = picture.GetDTO();

            pictureDTO.PictureURL = stream.ToString();
            if (pictureDTO.PictureURL.Contains(".jpg"))
            {
                pictureDTO.isImage = true;
            }
            else
            {
                pictureDTO.isImage = false;
            }

            return pictureDTO;
        }

        public async Task<IEnumerable<PictureDTO>> GetPicturesByGalleryID(int id)
        {
            string path = "";
            List<PictureDTO> pictureDTOs = new List<PictureDTO>();

            foreach (Page page in _qArteDBContext.Pages)
            {
                if (page.GalleryID == id)
                {
                    path = $"Users\\/{page.UserID}\\/{page.GalleryID}\\/";
                }
            }

            var gallery = await _qArteDBContext.Galleries
                .Include(x=>x.Pictures)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");
            GalleryDTO galleryDTO = gallery.GetDTO();

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);

            foreach(PictureDTO picture in galleryDTO.Pictures)
            {
                GetPreSignedUrlRequest getPreSignedUrlRequest = new GetPreSignedUrlRequest
                {
                    BucketName = _amazonData.BucketName,
                    Key = picture.PictureURL,
                    Expires = DateTime.UtcNow.AddMinutes(1)
                };

               var response = client.GetPreSignedURL(getPreSignedUrlRequest);

                PictureDTO pictureDTO = picture;
                pictureDTO.PictureURL = response;

                pictureDTOs.Add(pictureDTO);
                if (pictureDTO.PictureURL.Contains(".jpg"))
                {
                    pictureDTO.isImage = true;
                }
                else
                {
                    pictureDTO.isImage = false;
                }

            }

            return pictureDTOs;
        }

        public async Task<PictureDTO> PostAsync(PictureDTO obj)
        {
            string userID = "";
            string galleryID = obj.GalleryID.ToString();
            Random random = new Random();

            var findPage = await _qArteDBContext.Pages.FirstOrDefaultAsync(x => x.GalleryID == obj.GalleryID);
            userID = findPage.UserID.ToString();
            string path = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_{random.Next(1,1000000)+1}";
            if (obj.isImage)
            {
                path += ".jpg";
            }
            else
            {
                path += ".webm";
            }

            PictureDTO result = null;

            var deletedPicture = await _qArteDBContext.Pictures
                                            .Include(x => x.Gallery)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.GalleryID == obj.GalleryID && x.PictureURL == obj.PictureURL);

            
            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, _amazonData.BucketName);
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
                Key = path,
                InputStream = obj.file.OpenReadStream()
            };


            obj.PictureURL = path;
            var newPicture = obj.GetEntity();

            if (deletedPicture == null)
            {   await client.PutObjectAsync(objectRequest);

                await _qArteDBContext.Pictures.AddAsync(newPicture);
                await _qArteDBContext.SaveChangesAsync();
                result = newPicture.GetDTO();
            }
            else
            {
                result = deletedPicture.GetDTO();
            }
            result.file = obj.file;
            return result;
        }

        public async Task<PictureDTO> UpdateAsync(int id, PictureDTO obj)
        {

            string userID = "";
            string galleryID = obj.GalleryID.ToString();

            var findPage = await _qArteDBContext.Pages.FirstOrDefaultAsync(x => x.GalleryID == obj.GalleryID);
            userID = findPage.ID.ToString();
            string path = $"Users\\/{userID}\\/{galleryID}\\/{userID}_{galleryID}_{obj.ID}.jpg";


            var Picture = await _qArteDBContext.Pictures
                                .Include(x => x.Gallery)
                                .FirstOrDefaultAsync(x => x.ID == id)
                                ?? throw new AppException("Not found");

            if (obj.PictureURL == null)
            {
                throw new AppException("Bad input");
            }

            var region = RegionEndpoint.EUCentral1;
            AmazonS3Client client = new AmazonS3Client(_amazonData.AccessKey, _amazonData.SecretKey, region);
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, _amazonData.BucketName);
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
                Key = path,
                InputStream = obj.file.OpenReadStream()
            };
            obj.PictureURL = path;

            Picture.ID = obj.ID;
            Picture.PictureURL = obj.PictureURL;
            await _qArteDBContext.SaveChangesAsync();

            var pic = Picture.GetDTO();
            pic.file = obj.file;

            return pic;
        }
    }
}