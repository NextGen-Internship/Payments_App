﻿using QArte.Services.DTOs;
using QArte.Services.DTOMappers;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Persistance.Enums;
using QArte.Persistance;
using Microsoft.VisualBasic;
using QArte.Persistance.PersistanceModels;
using Stripe;

namespace QArte.Services.Services
{
	public class UserService : IUserService
	{

        private readonly QArteDBContext _qarteDBContext;
        private readonly IStripeService _stripeService;
        private readonly IBankAccountService _bankAccountService;
        private readonly IRoleService _roleService;

        private readonly IPaymentMethodsService _paymentMethodsService;
        private readonly ISettlementCycleService _settlementCycleService;
        private readonly IPageService _pageService;

        public UserService(QArteDBContext qarteDBContext, IStripeService stripeService, IBankAccountService bankAccountService, IRoleService roleService, IPaymentMethodsService paymentMethodsService, ISettlementCycleService settlementCycleService, IPageService pageService)
        {
            _qarteDBContext = qarteDBContext;
            _stripeService = stripeService;
            _bankAccountService = bankAccountService;
            _roleService = roleService;

            _paymentMethodsService = paymentMethodsService;
            _settlementCycleService = settlementCycleService;

            //_pageService = pageService;


            _pageService = pageService;
            _pageService = pageService;

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
                 .Include(x=>x.Pages)
                 .Include(x=>x.SettlementCycle)
                 .FirstOrDefaultAsync(x => x.ID == id)
                  ?? throw new ApplicationException("Not found");


            int bankAc = user.BankAccountID;

            _stripeService.DeleteSubAccount(user);

            _qarteDBContext.Users.Remove(user);

            await _qarteDBContext.SaveChangesAsync();

            await _bankAccountService.DeleteAsync(user.BankAccountID);

            await _roleService.DeleteAsync(user.RoleID);

            await _settlementCycleService.DeleteAsync(user.SettlementCycleID);

            foreach (Page page in user.Pages)
            {
                await _pageService.TotalDeleteAsync(page.ID);
            }

            return user.GetDTO();
        }

        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Pages)
                .Include(x => x.SettlementCycle)
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
                    BankAccountID = y.BankAccountID,
                    Country = y.Country,
                    StripeAccountID = y.StripeAccountID,
                    City = y.City,
                    postalCode = y.PostalCode,
                    Address = y.address,
                    SettlementCycleID = y.SettlementCycleID,
                    Pages = y.Pages.Select( y=> new PageDTO
                    {
                        ID = y.ID,
                        Bio = y.Bio,
                        GalleryID = y.GalleryID,
                        UserID = y.UserID,
                        QRLink = y.QRLink
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetBySettlementCycle(string settlementCycle)
        { 
            Enum.TryParse(typeof(ESettlementCycles), settlementCycle, out var parsedSettlementCycle);
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Pages)
                .Include(x => x.SettlementCycle)
                .Where(x=>x.SettlementCycle.SettlementCycles == (ESettlementCycles)parsedSettlementCycle)
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
                    BankAccountID = y.BankAccountID,
                    Country = y.Country,
                    StripeAccountID = y.StripeAccountID,
                    City = y.City,
                    postalCode = y.PostalCode,
                    Address = y.address,
                    SettlementCycleID = y.SettlementCycleID,
                    Pages = y.Pages.Select(y => new PageDTO
                    {
                        ID = y.ID,
                        Bio = y.Bio,
                        GalleryID = y.GalleryID,
                        UserID = y.UserID,
                        QRLink = y.QRLink
                    }).ToList()
                }).ToListAsync();

        }

        public async Task<string> GetEmailByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x=>x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.Email;
        }

        public async Task<string> GetStripeAccountByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.StripeAccountID;
        }

        public async Task<UserDTO> GetUserByStripeAccountID(string stripeId)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.StripeAccountID == stripeId)
                ?? throw new ApplicationException("Not found");

            return user.GetDTO();
        }

        public async Task<string> GetCountryByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.Country;
        }



        public async Task<UserDTO> GetUserByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x=>x.BankAccount)
                .Include(x=>x.Role)
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.GetDTO();
        }

        public async Task<string> GetUsernameByID(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.UserName;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByRoleID(int id)
        {
            return await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
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
                    BankAccountID = y.BankAccountID,
                    Country = y.Country,
                    StripeAccountID = y.StripeAccountID,
                    City = y.City,
                    Address = y.address,
                    postalCode = y.PostalCode,
                    SettlementCycleID = y.SettlementCycleID,
                    Pages = y.Pages.Select(y => new PageDTO
                    {
                        ID = y.ID,
                        Bio = y.Bio,
                        GalleryID = y.GalleryID,
                        UserID = y.UserID,
                        QRLink = y.QRLink
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<bool> isBanned(int id)
        {
            var user = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            return user.isBanned;
        }

        public async Task<UserDTO> PostAsync(UserDTO obj)
        {
            PaymentMethodDTO paymentMethodDTO = new PaymentMethodDTO
            {
                ID = 0,
                paymentName = obj.paymentMethodsEnum,
            };

            PaymentMethodDTO paymentMethodHolder = await _paymentMethodsService.PostAsync(paymentMethodDTO);

            BankAccountDTO bankAccountDTO = new BankAccountDTO
            {
                ID = 0,
                IBAN = obj.IBAN,
                PaymentMethodID = paymentMethodHolder.ID
            };

            BankAccountDTO bankHolder = await _bankAccountService.PostAsync(bankAccountDTO);

            RoleDTO roleDTO = new RoleDTO { ID = 0, ERole = obj.roleEnum };

            RoleDTO roleHolder = await _roleService.PostAsync(roleDTO);

            SettlementCycleDTO settlementCycle = new SettlementCycleDTO
            {
                ID = 0,
                SettlementCycles = obj.SettlementCycleEnum,
            };

            SettlementCycleDTO settlementCycleHolder = await _settlementCycleService.PostAsync(settlementCycle);
            //create the first page of the user
            PageDTO pageDTO = new PageDTO {
                ID = 0,
                Bio = "Your First Page!",
                QRLink = "User URL or whatever",
                UserID = 0,
                GalleryID = 0
            };
            
 //           PageDTO pageHolder = await _pageService.PostAsync(pageDTO);
            
            var deletedUser = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.isBanned == obj.isBanned && x.BankAccountID == obj.BankAccountID
                && x.Email == obj.Email && x.FirstName == obj.FirstName && x.LastName == obj.LastName &&
                x.Password == obj.Password && x.PictureUrl == obj.PictureURL && x.UserName == obj.Username
                && x.RoleID == obj.RoleID && x.StripeAccountID == obj.StripeAccountID && x.Country == obj.Country
                && x.City == obj.City && x.address == obj.Address && x.PostalCode == obj.postalCode);

            var newUser = obj.GetEnity();

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            if (deletedUser == null)
            {
//                newUser.Pages.Add(pageHolder.GetEntity());
                newUser.BankAccountID = bankHolder.ID;
                newUser.RoleID = roleHolder.ID;
                newUser.SettlementCycleID = settlementCycleHolder.ID;

                await _qarteDBContext.Users.AddAsync(newUser);
                
                newUser.StripeAccountID = await _stripeService.CreateSubAccountAsync(newUser, bankHolder);
                await _qarteDBContext.SaveChangesAsync();
                return newUser.GetDTO();
            }



            return deletedUser.GetDTO();
        }

        public async Task<UserDTO> CreateAsync(UserDTO obj)
        {
            BankAccountDTO bankAccountDTO = new BankAccountDTO
            {
                IBAN = obj.IBAN,
                ID = 0,
                PaymentMethodID = 1
            };
            RoleDTO roleDTO = new RoleDTO { ID = 0, ERole = ERoles.Artist };


            var deletedUser = await _qarteDBContext.Users
                .Include(x => x.BankAccount)
                .Include(x => x.Role)
                .Include(x => x.SettlementCycle)
                .FirstOrDefaultAsync(x => x.isBanned == obj.isBanned && x.BankAccountID == obj.BankAccountID
                && x.Email == obj.Email && x.FirstName == obj.FirstName && x.LastName == obj.LastName &&
                x.Password == obj.Password && x.PictureUrl == obj.PictureURL && x.UserName == obj.Username
                && x.RoleID == obj.RoleID && x.StripeAccountID == obj.StripeAccountID && x.Country == obj.Country
                && x.City == obj.City && x.address == obj.Address && x.PostalCode == obj.postalCode
                && x.SettlementCycleID == obj.SettlementCycleID);

            var newUser = obj.GetEnity();

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);



            if (deletedUser == null)
            {
                BankAccountDTO bankHolder = await _bankAccountService.PostAsync(bankAccountDTO);
                RoleDTO roleHolder = await _roleService.PostAsync(roleDTO);
                newUser.BankAccountID = bankHolder.ID;
                newUser.RoleID = roleHolder.ID;
                await _qarteDBContext.Users.AddAsync(newUser);

                BankAccountDTO bankAccount = await _bankAccountService.GetByIDAsync(newUser.BankAccountID);

                //newUser.StripeAccountID = await _stripeService.CreateSubAccountAsync(newUser, bankAccount);
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
                .Include(x=>x.Pages)
                .Include(x => x.SettlementCycle)
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
            user.address = obj.Address;
            user.City = obj.City;
            user.PostalCode = obj.postalCode;
            user.SettlementCycleID = obj.SettlementCycleID;

            await _qarteDBContext.SaveChangesAsync();

            return user.GetDTO();

        }

        public async Task<UserDTO> FindByEmailAsync(string email)
        {
            var model = await _qarteDBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return model?.GetDTO();
        }

        //here it should be User user or UserDTO user???
        public bool CheckByPasswordSignIn(UserDTO user, string password)
        {
            //import BCrypt.Net-Next
            //the first return -> if we use User user
            //return BCrypt.Net.BCrypt.Verify(password, user.Password);

            //the second return -> if we use UserDTO user
            var result = BCrypt.Net.BCrypt.Verify(password, user.Password);

            return result;

        }

        Task<List<UserDTO>> IUserService.GetBySettlementCycle(string settlementCycle)
        {
            throw new NotImplementedException();
        }
    }
}

