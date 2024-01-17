using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IPageService : ICRUDshared<PageDTO>
	{
		Task<PageDTO> GetPageByID(int id);
		Task<IQueryable<PageDTO>> GetPagesByUserID(int id);
    }
}

