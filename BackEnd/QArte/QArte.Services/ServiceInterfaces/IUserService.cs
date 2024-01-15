using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.ServiceInterfaces
{
	public interface IUserService : ICRUDshared<UserDTO>
	{
		Task<UserDTO> GetUserByID(int id);
		Task<string> GetEmailByID(int id);
		Task<string> GetUsernameByID(int id);
		Task<IQueryable<UserDTO>> GetUsersByRoleID(int id);
        Task<IQueryable<PageDTO>> GetPagesByUserID(int id);
		Task<bool> isBanned(int id);
		
    }
}

