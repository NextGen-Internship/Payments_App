using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance;
using QArte.Persistance.Helpers;
using Microsoft.Extensions.Configuration;

namespace QArte.Services.Services
{
	public class PageService : IPageService
	{

        private readonly QArteDBContext _qArteDBContext;
        private readonly IQRCodeGeneratorService _qRCodeGenerator;
        private readonly IGalleryService _galleryService;
        private readonly IConfiguration _configuration;

        public PageService(QArteDBContext qArteDBContext, IQRCodeGeneratorService qR, IGalleryService galleryService, IConfiguration configuration)
        {
            this._qArteDBContext = qArteDBContext;
            _qRCodeGenerator = qR;
            _galleryService = galleryService;
            _configuration = configuration;
        }

        public async Task<PageDTO> DeleteAsync(int id)
        {
            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            
            _qRCodeGenerator.DeleteQRCode(page.GalleryID.ToString(),page.UserID.ToString());

            this._qArteDBContext.Pages.Remove(page);
            await _galleryService.DeleteAsync(page.GalleryID);
            await _qArteDBContext.SaveChangesAsync();
            
           

            return page.GetDTO();
        }

        public async Task<PageDTO> TotalDeleteAsync(int id)
        {
            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            _qRCodeGenerator.TotalDeleteQRCode(page.GalleryID.ToString(), page.UserID.ToString());

            

            this._qArteDBContext.Pages.Remove(page);
            await _galleryService.DeleteAsync(page.GalleryID);
            await _qArteDBContext.SaveChangesAsync();

            return page.GetDTO();
        }

        public async Task<IEnumerable<PageDTO>> GetAsync()
        {
            return await this._qArteDBContext.Pages
                .Select(x => new PageDTO
                {
                    ID = x.ID,
                    PageName = x.PageName,
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
              ?? throw new AppException("Not found");
            return page.GetDTO();
        }

        public async Task<IEnumerable<PageDTO>> GetPagesByUserID(int id)
        {
            return await this._qArteDBContext.Pages
                .Where(x => x.UserID == id)
                .Select(x => new PageDTO
                {
                    ID = x.ID,
                    PageName = x.PageName,
                    Bio = x.Bio,
                    QRLink = x.QRLink,
                    GalleryID = x.GalleryID,
                    UserID = x.UserID
                }).ToListAsync();
        }

        public async Task<PageDTO> PostAsync(PageDTO obj)
        {


            string qrLink = $"{_configuration["URL"]}/explore/{obj.UserID}/";


            PageDTO result = null;

            GalleryDTO galleryDTO = new GalleryDTO
            {
                ID = 0,
                Pictures = {},
            };

            var newPage = obj.GetEntity();

            if (newPage.GalleryID == 0)
            {
                GalleryDTO galleryHolder = await _galleryService.PostAsync(galleryDTO);
                newPage.GalleryID = galleryHolder.ID;
            }
            await this._qArteDBContext.Pages.AddAsync(newPage);
            await _qArteDBContext.SaveChangesAsync();

            var page = await this._qArteDBContext.Pages
                .FirstOrDefaultAsync(x => x.GalleryID == newPage.GalleryID);

            page.QRLink = qrLink + page.ID;
            await _qArteDBContext.SaveChangesAsync();

            var user = await _qArteDBContext.Users.
                FirstOrDefaultAsync(x => x.ID == newPage.UserID);

            string userEmail = user.Email;
            _qRCodeGenerator.CreateQRCode(newPage.QRLink, newPage.GalleryID.ToString(), newPage.UserID.ToString(), newPage.User.Email);

            result = newPage.GetDTO();
            


            return result;
        }

        public async Task<PageDTO> UpdateAsync(int id, PageDTO obj)
        {
            var page = await this._qArteDBContext.Pages
                .Include(x => x.Gallery)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new AppException("Not found");

            if (obj.QRLink == null)
            {
                throw new AppException("Bad input");
            }

            page.ID = obj.ID;
            page.PageName = obj.PageName;
            page.Bio = obj.Bio;
            await _qArteDBContext.SaveChangesAsync();

            return page.GetDTO();
        }

        public async Task<PageDTO> GetQRCode(int id)
        {
            var page = await _qArteDBContext.Pages
              .FirstOrDefaultAsync(x => x.ID == id)
              ?? throw new AppException("Not found");
            var user = await _qArteDBContext.Users
                .FirstOrDefaultAsync(x => x.ID == page.UserID);

            _qRCodeGenerator.GetQRCode(page.GalleryID.ToString(), page.UserID.ToString(), user.Email);

            return page.GetDTO();
        }
    }
}

