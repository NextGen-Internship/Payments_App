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

        private readonly QArteDBContext _qarteDBContext;

        public UserService(QArteDBContext qarteDBContext)
        {
            _qarteDBContext = qarteDBContext;
        }

        public Task<UserDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Ban)
                .Select(y => new UserDTO
                {
                    ID = y.ID,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Username = y.UserName,
                    Password = y.Password,
                    Email = y.Email,
                    PictureURL = y.PictureUrl,
                    PhoneNumber = y.PhoneNumber,
                    RoleID = y.RoleID,
                    BanID = y.BanID,
                    BankAccountID = y.BankAccountID
                }).ToListAsync();
        }

        public async Task<string> GetEmailByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Ban)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.Email;
        }

        public async Task<UserDTO> GetUserByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x=>x.BankAccount)
                .Include(x=>x.Role)
                .Include(x=>x.Ban)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.GetDTO();
        }

        public async Task<string> GetUsernameByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Ban)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.UserName;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByRoleID(int id)
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Ban)
                .Where(x=>x.RoleID == id)
                .Select(y => new UserDTO
                {
                    ID = y.ID,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Username = y.UserName,
                    Password = y.Password,
                    Email = y.Email,
                    PictureURL = y.PictureUrl,
                    PhoneNumber = y.PhoneNumber,
                    RoleID = y.RoleID,
                    BanID = y.BanID,
                    BankAccountID = y.BankAccountID
                }).ToListAsync();
        }

        public async Task<bool> isBanned(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Ban)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");


            IBanTableService _banTableService = new BanTableService(_qarteDBContext);

            var banTable = await _banTableService.GetBanTableByID(user.BanID);

            if (banTable.BanID != 0)
                return true;

            return false;
        }

        public async Task<UserDTO> PostAsync(UserDTO obj)
        { 

            var deletedUser = await _qarteDBContext.Users
                .Include(x => x.Ban)
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.BanID == obj.BanID && x.BankAccountID == obj.BankAccountID
                && x.Email == obj.Email && x.FirstName == obj.FirstName && x.LastName == obj.LastName &&
                x.Password == obj.Password && x.PictureUrl == obj.PictureURL && x.UserName == obj.Username
                && x.RoleID == obj.RoleID);

            var newUser = obj.GetEnity();

            if (deletedUser == null)
            {
                await _qarteDBContext.Users.AddAsync(newUser);
                await _qarteDBContext.SaveChangesAsync();
                return newUser.GetDTO();
            }

            return deletedUser.GetDTO();
        }

        public Task<UserDTO> UpdateAsync(int id, UserDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}

