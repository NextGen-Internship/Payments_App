using QArte.Services.DTOs;
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
        private QRCodeGeneratorService _qRCodeGenerator;

		public PageService(QArteDBContext qArteDBContext, QRCodeGeneratorService qR)
		{
            this._qArteDBContext = qArteDBContext;
            _qRCodeGenerator = qR;
		}

        public async Task<PageDTO> DeleteAsync(int id)
        {
            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            _qRCodeGenerator.DeleteQRCode(page.ID.ToString(),page.UserID.ToString());

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

            var deletedPage = await _qArteDBContext.Pages
                                            .Include(x => x.Gallery)
                                            .Include(x => x.User)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.QRLink == obj.QRLink);
            var newPage = obj.GetEntity();
            if (deletedPage == null)
            {
                await this._qArteDBContext.Pages.AddAsync(newPage);
                await _qArteDBContext.SaveChangesAsync();
                _qRCodeGenerator.CreateQRCode(newPage.QRLink, newPage.ID.ToString(), newPage.UserID.ToString());
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

