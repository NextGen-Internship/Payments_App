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
	public class GalleryService : IGalleryService
	{
		public GalleryService()
		{
		}

        public Task<GalleryDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GalleryDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDTO> GetGalleryByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDTO> PostAsync(GalleryDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<GalleryDTO> UpdateAsync(int id, GalleryDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

