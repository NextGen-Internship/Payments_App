using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IRoleService : ICRUDshared<RoleDTO>
	{
		Task<RoleDTO> GetRoleByID(int id);
	}
}

