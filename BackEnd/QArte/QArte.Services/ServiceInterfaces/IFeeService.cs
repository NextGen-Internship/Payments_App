using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IFeeService :ICRUDshared<FeeDTO>
	{
		Task<FeeDTO> GetFeeByID(int id);
		Task<IEnumerable<FeeDTO>> GetFeesByCurrency(string Currency);
	}
}

