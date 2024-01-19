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

        public async Task<bool> UserExists(int id, string username, string email)
        {
            return await _qarteDBContext.Users.AnyAsync(x => x.ID == id && x.UserName == username && x.Email == email);
        }

        public async Task<UserDTO> DeleteAsync(int id)
        {
            var user = await _qarteDBContext.Users
                 .Include(x=>x.BankAccount)
                 .Include(x=>x.Role)
                 .FirstOrDefaultAsync(x => x.ID == id)
                  ?? throw new ApplicationException("Not found");

            _qarteDBContext.Users.Remove(user);
            await _qarteDBContext.SaveChangesAsync();

            return user.GetDTO();
        }

        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
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
                    isBanned = y.isBanned,
                    RoleID = y.RoleID,
                    BankAccountID = y.BankAccountID
                }).ToListAsync();
        }

        public async Task<string> GetEmailByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.Email;
        }

        public async Task<UserDTO> GetUserByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x=>x.BankAccount)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.GetDTO();
        }

        public async Task<string> GetUsernameByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.UserName;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByRoleID(int id)
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Where(x => x.RoleID == id)
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
                    isBanned = y.isBanned,
                    RoleID = y.RoleID,
                    BankAccountID = y.BankAccountID
                }).ToListAsync();
        }

        public async Task<bool> isBanned(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.isBanned;
        }

        public async Task<UserDTO> PostAsync(UserDTO obj)
        { 

            var deletedUser = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.isBanned == obj.isBanned && x.BankAccountID == obj.BankAccountID
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

        public async Task<UserDTO> UpdateAsync(int id, UserDTO obj)
        {
            _ = await UserExists(obj.ID, obj.Username, obj.Email)
                == true ? throw new ApplicationException("Not found") : 0;

            var user = await _qarteDBContext.Users
                .Include(x => x.Role)
                .Include(x => x.BankAccount)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            user.ID = obj.ID;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.UserName = obj.Username;
            user.Password = obj.Password;
            user.Email = obj.Email;
            user.PictureUrl = obj.PictureURL;
            user.PhoneNumber = obj.PhoneNumber;
            user.isBanned = obj.isBanned;
            user.RoleID = obj.RoleID;
            user.BankAccountID = obj.BankAccountID;

            await _qarteDBContext.SaveChangesAsync();

            return user.GetDTO();

        }


    }
}

