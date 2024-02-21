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
		Task<IEnumerable<PageDTO>> GetPagesByUserID(int id);
        Task<PageDTO> TotalDeleteAsync(int iD);
		Task<PageDTO> GetQRCode(int id);
    }
}

