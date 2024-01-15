using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;


namespace QArte.Services.ServiceInterfaces
{
	public interface IBanTableService : ICRUDshared<BanTableDTO>
	{
		Task<BanTableDTO> GetBanTableByID();
	}
}

