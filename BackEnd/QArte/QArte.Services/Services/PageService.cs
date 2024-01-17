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
	public class PageService : IPageService
	{
		public PageService()
		{
		}

        public Task<PageDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PageDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PageDTO> GetPageByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PageDTO>> GetPagesByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageDTO> PostAsync(PageDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<PageDTO> UpdateAsync(int id, PageDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

