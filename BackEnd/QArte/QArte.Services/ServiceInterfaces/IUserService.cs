using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;
using Microsoft.AspNetCore.Http;

namespace QArte.Services.ServiceInterfaces
{
    public interface IUserService : ICRUDshared<UserDTO>
    {
        Task<UserDTO> GetUserByID(int id);
        Task<string> GetEmailByID(int id);
        Task<string> GetUsernameByID(int id);
        Task<IEnumerable<UserDTO>> GetUsersByRoleID(int id);
        Task<bool> isBanned(int id);
        Task<string> GetStripeAccountByID(int id);
        Task<string> GetCountryByID(int id);
		Task<IEnumerable<UserDTO>> GetBySettlementCycle(string settlementCycle);
		Task<UserDTO> GetUserByStripeAccountID(string stripeId);
		Task<UserDTO> PostUserProfilePicture(int id,IFormFile profilePicture);
        Task<UserDTO> FindByEmailAsync(string email);
        bool CheckByPasswordSignIn(UserDTO user, string password);
        //Task<List<UserDTO>> GetBySettlementCycle(string settlementCycle);
        string GetProfilePictureByUser(UserDTO user);
        Task<UserDTO> PatchUsername(int id, string userName);
    }
}