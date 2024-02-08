﻿using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;
using QArte.Services.Services;

namespace QArte.Services.Services
{
	public class PageService : IPageService
	{

        private readonly QArteDBContext _qArteDBContext;
        private readonly QRCodeGeneratorService _qRCodeGenerator;
        private readonly GalleryService _galleryService;

		public PageService(QArteDBContext qArteDBContext, QRCodeGeneratorService qR, GalleryService galleryService)
		{
            this._qArteDBContext = qArteDBContext;
            _qRCodeGenerator = qR;
            _galleryService = galleryService;
		}

        public async Task<PageDTO> DeleteAsync(int id)
        {
            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");
            if(this._qArteDBContext.Pages.Count() >= 2)
            {
                _qRCodeGenerator.DeleteQRCode(page.GalleryID.ToString(),page.UserID.ToString());

                await _galleryService.DeleteAsync(page.GalleryID);

                this._qArteDBContext.Pages.Remove(page);
                await _qArteDBContext.SaveChangesAsync();
            }
           

            return page.GetDTO();
        }

        public async Task<PageDTO> TotalDeleteAsync(int id)
        {
            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            _qRCodeGenerator.TotalDeleteQRCode(page.GalleryID.ToString(), page.UserID.ToString());

            await _galleryService.DeleteAsync(page.GalleryID);

            this._qArteDBContext.Pages.Remove(page);
            await _qArteDBContext.SaveChangesAsync();

            return page.GetDTO();
        }

        public async Task<IEnumerable<PageDTO>> GetAsync()
        {
            return await this._qArteDBContext.Pages
                .Select(x => new PageDTO
                {
                    ID = x.ID,
                    Bio = x.Bio,
                    QRLink = x.QRLink,
                    GalleryID = x.GalleryID,
                    UserID = x.UserID
                }).ToListAsync();
        }

        public async Task<PageDTO> GetPageByID(int id)
        {
            var page = await _qArteDBContext.Pages
              .FirstOrDefaultAsync(x => x.ID == id)
              ?? throw new ApplicationException("Not found");
            return page.GetDTO();
        }

        public async Task<IEnumerable<PageDTO>> GetPagesByUserID(int id)
        {
            return await this._qArteDBContext.Pages
                .Where(x => x.UserID == id)
                .Select(x => new PageDTO
                {
                    ID = x.ID,
                    Bio = x.Bio,
                    QRLink = x.QRLink,
                    GalleryID = x.GalleryID,
                    UserID = x.UserID
                }).ToListAsync();
        }

        public async Task<PageDTO> PostAsync(PageDTO obj)
        {
            PageDTO result = null;

            GalleryDTO galleryDTO = new GalleryDTO
            {
                ID = 0,
                Pictures = {},
            };

            var deletedPage = await _qArteDBContext.Pages
                                            .Include(x => x.Gallery)
                                            .Include(x => x.User)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.QRLink == obj.QRLink);
            var newPage = obj.GetEntity();
            if (deletedPage == null)
            {

                GalleryDTO galleryHolder = await _galleryService.PostAsync(galleryDTO);
                newPage.GalleryID = galleryHolder.ID;
                newPage.Gallery = galleryHolder.GetEntity();

                await this._qArteDBContext.Pages.AddAsync(newPage);
                await _qArteDBContext.SaveChangesAsync();
                var user = await _qArteDBContext.Users.
                    FirstOrDefaultAsync(x => x.ID == newPage.UserID);
                string userEmail = user.Email;
                _qRCodeGenerator.CreateQRCode(newPage.QRLink, newPage.GalleryID.ToString(), newPage.UserID.ToString(), newPage.User.Email);

                result = newPage.GetDTO();
            }
            else
            {
                result = deletedPage.GetDTO();

            }

            return result;
        }

        public async Task<PageDTO> UpdateAsync(int id, PageDTO obj)
        {
            var page = await this._qArteDBContext.Pages
                .Include(x => x.Gallery)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            if (obj.QRLink == null)
            {
                throw new ApplicationException("Bad input");
            }

            page.ID = obj.ID;
            page.Bio = obj.Bio;
            await _qArteDBContext.SaveChangesAsync();

            return page.GetDTO();
        }

    }
}

