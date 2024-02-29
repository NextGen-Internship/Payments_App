using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance;
using QArte.Persistance.PersistanceModels;
using QArte.Persistance.Helpers;

namespace QArte.Services.Services
{
	public class GalleryService : IGalleryService
	{
        private readonly QArteDBContext _qarteDBContext;
        private readonly IPictureService _pictureService;

		public GalleryService(QArteDBContext qArteDBContext, IPictureService pictureService)
		{
            _qarteDBContext = qArteDBContext;
            _pictureService = pictureService;
		}

        public async Task<GalleryDTO> DeleteAsync(int id)
        {
            

            var gallery = await _qarteDBContext.Galleries
                .Include(x=>x.Pictures)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new AppException("Not found");

            
            

            foreach(Picture picture in gallery.Pictures)
            {
                await _pictureService.DeleteAsync(picture.ID);
            }
            _qarteDBContext.Galleries.Remove(gallery);
            await _qarteDBContext.SaveChangesAsync();

            return gallery.GetDTO();
        }

        public async Task<IEnumerable<GalleryDTO>> GetAsync()
        {
            return await _qarteDBContext.Galleries
                .Include(x => x.Pictures)
                .Select(x => new GalleryDTO
                {
                    ID = x.ID,
                    Pictures = x.Pictures.Select(y => new PictureDTO
                    {
                        ID = y.ID,
                        PictureURL = y.PictureURL,
                        GalleryID = y.GalleryID,
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<GalleryDTO> GetGalleryByID(int id)
        {
            var gallery = await _qarteDBContext.Galleries
                       .Include(x => x.Pictures)
                       .FirstOrDefaultAsync(x => x.ID == id)
                       ?? throw new AppException("Not found");

            return gallery.GetDTO();
        }

        public async Task<GalleryDTO> PostAsync(GalleryDTO obj)
        {

            var newGallery = obj.GetEntity();

            await _qarteDBContext.Galleries.AddAsync(newGallery);
            await _qarteDBContext.SaveChangesAsync();

            return newGallery.GetDTO();   
;        }

        public async Task<GalleryDTO> UpdateAsync(int id, GalleryDTO obj)
        {
            var Gallery = await _qarteDBContext.Galleries
                .Include(x=>x.Pictures)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new AppException("Not found");

            Gallery.ID = obj.ID;
            await _qarteDBContext.SaveChangesAsync();

            return Gallery.GetDTO();
        }
    }
}

