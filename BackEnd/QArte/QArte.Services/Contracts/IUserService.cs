using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Services.Contracts
{
	public interface IUserService : ICRUDshared<UserDTO>
	{
		Task<UserDTO> GetUserByID(int id);
		string GetEmailByID(int id);
		string GetUsernameByID(int id);
		Task<IQueryable<UserDTO>> GetUsersByRoleID(int id);
        Task<IQueryable<PageDTO>> GetPagesByUserID(int id);
		bool isBanned(int id);
		
    }
}

