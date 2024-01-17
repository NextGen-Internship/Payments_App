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
	public class RoleService : IRoleService
	{
		public RoleService()
		{
		}

        public Task<RoleDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO> GetRoleByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO> PostAsync(RoleDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO> UpdateAsync(int id, RoleDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

