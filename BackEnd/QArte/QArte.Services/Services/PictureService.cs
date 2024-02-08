using System;
using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;

namespace QArte.Services.Services
{
    public class PictureService : IPictureService
    {
        //make it so it works with the amazon!
        private readonly QArteDBContext _qArteDBContext;

        public PictureService(QArteDBContext qArteDBContext)
        {
            _qArteDBContext = qArteDBContext;
        }

        public async Task<PictureDTO> DeleteAsync(int id)
        {
            //Make it so it get deleted from the amazon
            var picture = await _qArteDBContext.Pictures
                .Include(x => x.Gallery)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

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

            Picture.ID = obj.ID;
            Picture.PictureURL = obj.PictureURL;
            await _qArteDBContext.SaveChangesAsync();

            return Picture.GetDTO();
        }
    }
}