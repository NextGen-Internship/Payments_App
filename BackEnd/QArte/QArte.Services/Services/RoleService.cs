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
        private readonly QArteDBContext _qArteDBContext;

		public RoleService(QArteDBContext qArteDBContext)
		{
            _qArteDBContext = qArteDBContext;
		}


        public async Task<RoleDTO> DeleteAsync(int id)
        {
            var role = await this._qArteDBContext.Roles
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            this._qArteDBContext.Roles.Remove(role);
            await _qArteDBContext.SaveChangesAsync();

            return role.GetDTO();
        }

        public async Task<IEnumerable<RoleDTO>> GetAsync()
        {
            return await this._qArteDBContext.Roles
                .Select(x => new RoleDTO
                {
                    ID = x.ID,
                    ERole = x.ERole,
                    Users = x.Users
                    .Select(y => new UserDTO
                    {
                        ID = y.ID,

                    }).ToList()
                }).ToListAsync();
        }

        public async Task<RoleDTO> GetRoleByID(int id)
        {
            var role = await _qArteDBContext.Roles
              .Include(x=>x.Users)
              .FirstOrDefaultAsync(x => x.ID == id)
              ?? throw new ApplicationException("Not found");
            return role.GetDTO();
        }

        public async Task<RoleDTO> PostAsync(RoleDTO obj)
        {
            RoleDTO result = null;

            var deletedRole = await _qArteDBContext.Roles
                                            .Include(x => x.Users)
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.ID== obj.ID);
            var newRole = obj.GetEnity();
            if (deletedRole == null)
            {
                await this._qArteDBContext.Roles.AddAsync(newRole);
                await _qArteDBContext.SaveChangesAsync();
                result = newRole.GetDTO();
            }
            else
            {
                result = deletedRole.GetDTO();

            }

            return result;
        }

        public async Task<RoleDTO> UpdateAsync(int id, RoleDTO obj)
        {
            var Role = await this._qArteDBContext.Roles
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            Role.ID = obj.ID;
            Role.ERole = obj.ERole;
            await _qArteDBContext.SaveChangesAsync();

            return Role.GetDTO();
        }
    }
}

