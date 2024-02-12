using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
    public static class UserDTOMapperExtension
    {
        public static UserDTO GetDTO(this User user)
        {
            if (user is null)
            {
                throw new ApplicationException("This user is null");
            }

            return new UserDTO
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Password = user.Password,
                Email = user.Email,
                PictureURL = user.PictureUrl,
                PhoneNumber = user.PhoneNumber,
                isBanned = user.isBanned,
                RoleID = user.RoleID,
                BankAccountID = user.BankAccountID,
                Country = user.Country,
                StripeAccountID = user.StripeAccountID,
                City = user.City,
                Address = user.address,
                postalCode = user.PostalCode,
                SettlementCycleID = user.SettlementCycleID
                
            };
        }

        public static User GetEnity(this UserDTO userDTO)
        {
            if (userDTO is null)
            {
                throw new ApplicationException("This userDTO is null");
            }

            List<Page> pages = new List<Page>();
            foreach(PageDTO pageDTO in userDTO.Pages)
            {
                pages.Add(pageDTO.GetEntity());
            }
            return new User
            {
                ID = userDTO.ID,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                UserName = userDTO.Username,
                Password = userDTO.Password,
                Email = userDTO.Email,
                PictureUrl = userDTO.PictureURL,
                PhoneNumber = userDTO.PhoneNumber,
                isBanned = userDTO.isBanned,
                RoleID = userDTO.RoleID,
                BankAccountID = userDTO.BankAccountID,
                Country = userDTO.Country,
                StripeAccountID = userDTO.StripeAccountID,
                City = userDTO.City,
                address = userDTO.Address,
                PostalCode = userDTO.postalCode,
                SettlementCycleID = userDTO.SettlementCycleID,
               
                
            };
        }
    }
}

