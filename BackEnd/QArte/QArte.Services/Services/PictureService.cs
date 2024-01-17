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
		public PictureService()
		{
		}

        public Task<PictureDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PictureDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PictureDTO> GetPictureByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PictureDTO> GetPicturesByGalleryID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PictureDTO> PostAsync(PictureDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<PictureDTO> UpdateAsync(int id, PictureDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

