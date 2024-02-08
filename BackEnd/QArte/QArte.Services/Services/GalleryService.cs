﻿using System;
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
        private readonly QArteDBContext _qarteDBContext;
        private readonly PictureService _pictureService;

		public GalleryService(QArteDBContext qArteDBContext, PictureService pictureService)
		{
            _qarteDBContext = qArteDBContext;
            _pictureService = pictureService;
		}

        public async Task<GalleryDTO> DeleteAsync(int id)
        {
            

            var gallery = await _qarteDBContext.Galleries
                .Include(x=>x.Pictures)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new ApplicationException("Not found");

            


            _qarteDBContext.Galleries.Remove(gallery);

            foreach(Picture picture in gallery.Pictures)
            {
                await _pictureService.DeleteAsync(picture.ID);
            }
            
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
                       ?? throw new ApplicationException("Not found");

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
                ?? throw new ApplicationException("Not found");

            Gallery.ID = obj.ID;
            await _qarteDBContext.SaveChangesAsync();

            return Gallery.GetDTO();
        }
    }
}

