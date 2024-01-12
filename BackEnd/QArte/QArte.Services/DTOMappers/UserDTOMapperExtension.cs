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
                Username= user.UserName,
                Password = user.Password,
                Email = user.Email,
                PictureURL = user.PictureUrl,
                PhoneNumber = user.PhoneNumber,
                RoleID = user.RoleID,
                BanID = user.BanID,
                BankAccountID = user.BankAccountID
            };
        }

        public static User GetEnity(this UserDTO userDTO)
        {
            if (userDTO is null)
            {
                throw new ApplicationException("This userDTO is null");
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
                RoleID = userDTO.RoleID,
                BanID = userDTO.BanID,
                BankAccountID = userDTO.BankAccountID
            };
        }
    }
}

