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
	public class UserService : IUserService
	{
		public UserService()
		{
		}

        public Task<UserDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PageDTO>> GetPagesByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUsernameByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserDTO>> GetUsersByRoleID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isBanned(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> PostAsync(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateAsync(int id, UserDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

