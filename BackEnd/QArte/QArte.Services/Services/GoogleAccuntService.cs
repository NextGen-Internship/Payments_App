
﻿using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;

﻿//using System;
//using QArte.Services.DTOs;
//using System.Threading.Tasks;

//using System.Collections.Generic;
//using QArte.Persistance.Enums;
//using QArte.Persistance;
//using QArte.Services.ServiceInterfaces;
//using Microsoft.EntityFrameworkCore;
//using QArte.Services.DTOMappers;
//using System.Threading.Tasks;
//using QArte.Persistance.PersistanceModels;

//namespace QArte.Services.Services
//{
//	public class GoogleAccuntService : IGoogleAccountService
//	{
//        private readonly QArteDBContext _qArteDBContext;

//        public GoogleAccuntService(QArteDBContext qArteDBContext)
//        {
//            _qArteDBContext = qArteDBContext;
//        }

//        //takes an emailaddress and add new googleaccount with this email to the db
//        public async Task AddGoogleAccount(string email)
//        {
//            await _qArteDBContext.GoogleAccount.AddAsync(new GoogleAccount { Email = email });
//            await _qArteDBContext.SaveChangesAsync();
//        }

//        //checked if the googleaccount with this epec email exists into the db
//        public async Task<bool> IsGoogleAccount(string email)
//        {
//            return await _qArteDBContext.GoogleAccount.AnyAsync(x => x.Email == email);
//        }

//        //with the spec email delete the googleaccount from the db
//        public async Task DeleteGoogleAccount(string email)
//        {
//            var user = await _qArteDBContext.GoogleAccount.FirstOrDefaultAsync(x => x.Email == email);
//            if (user != null)
//            {
//                _qArteDBContext.GoogleAccount.Remove(user);
//                await _qArteDBContext.SaveChangesAsync();
//            }
//        }
//    }
//}

