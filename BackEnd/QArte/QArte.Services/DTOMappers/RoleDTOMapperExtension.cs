using System;
using QArte.Persistance.PersistanceModels;
using QArte.Services.DTOs;

namespace QArte.Services.DTOMappers
{
	public static class RoleDTOMapperExtension
    {
        public static RoleDTO GetDTO(this Role role)
        {
            if (role is null)
            {
                throw new ApplicationException("This role is null");
            }

            //List<UserDTO> userDTOs = new List<UserDTO>();

            //foreach (User user in role.Users)
            //{
            //    userDTOs.Add(new UserDTO { ID = user.ID, FirstName = user.FirstName, LastName = user.LastName,
            //        Username = user.UserName, Password = user.Password, Email = user.Email, PictureURL = user.PictureUrl,
            //        PhoneNumber = user.PhoneNumber, RoleID = user.RoleID,isBanned = user.isBanned, BankAccountID = user.BankAccountID});
            //}


            return new RoleDTO
            {
                ID = role.ID,
                ERole = role.ERole,
                //Users = userDTOs
            };

        }
        public static Role GetEnity(this RoleDTO roleDTO)
        {
            if (roleDTO is null)
            {
                throw new ApplicationException("This roleDTO is null");
            }

            //List<User> users = new List<User>();

            //foreach (UserDTO userDTO in roleDTO.Users)
            //{
            //    users.Add(new User
            //    {
            //        ID = userDTO.ID,
            //        FirstName = userDTO.FirstName,
            //        LastName = userDTO.LastName,
            //        UserName = userDTO.Username,
            //        Password = userDTO.Password,
            //        Email = userDTO.Email,
            //        PictureUrl = userDTO.PictureURL,
            //        PhoneNumber = userDTO.PhoneNumber,
            //        isBanned = userDTO.isBanned,
            //        RoleID = userDTO.RoleID,
            //        BankAccountID = userDTO.BankAccountID
            //    }) ;
            //}


            return new Role
            {
                ID = roleDTO.ID,
                ERole = roleDTO.ERole,
                //Users = users
            };

        }
    }
}

