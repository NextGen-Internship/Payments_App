using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using QArte.Persistance.Enums;

namespace QArte.Persistance.PersistanceModels.DAL
{
	public static class Seeder
	{
		public static void Seed(this ModelBuilder db)
		{
			//var userId0 = Guid.NewGuid();

			//var userId1 = Guid.NewGuid();

   //         var userId2 = Guid.NewGuid();

			var paymentMethod = new List<PaymentMethod>()
			{
				new PaymentMethod
				{
					ID = 1,
					PaymentMethods = EPaymentMethods.Revolut
				},
				new PaymentMethod
				{
					ID = 2,
					PaymentMethods = EPaymentMethods.IBAN
				}
			};

			db.Entity<PaymentMethod>().HasData(paymentMethod);

			var settlementCycle = new List<SettlementCycle>()
			{
				new SettlementCycle
				{
					ID = 1,
					DatePeriod = System.DateTime.Today
				},
				new SettlementCycle
				{
					ID = 2,
					DatePeriod = System.DateTime.Today.AddDays(5)
                }
            };

            db.Entity<SettlementCycle>().HasData(settlementCycle);

			var fee = new List<Fee>()
			{
				new Fee
				{
					ID = 1,
					Amount = 69.5M,
					Currency = "EUR",
					ExchangeRate = 4.3M
				}
			};
            db.Entity<Fee>().HasData(fee);


			var invoice = new List<Invoice>()
			{
				new Invoice
				{
					ID = 1,
					TotalAmount = 69.69M,
					InvoiceDate = System.DateTime.Today.AddDays(120),
					BankAccountID = 1,
					SettlementCycleID = 2
				},
				new Invoice
				{
					ID = 2,
					TotalAmount = 69.420M,
					InvoiceDate = System.DateTime.Today.AddDays(653),
					BankAccountID = 2,
					SettlementCycleID = 1
				}

			};
            db.Entity<Invoice>().HasData(invoice);


			var bankAccount = new List<BankAccount>()
			{
				new BankAccount
				{
					ID = 1,
					IBAN = "BG42TTBB94008757957164",
					BeneficiaryName = "Stefan Dobrev",
					StripeInfo = "albala",
					PaymentMethodID = 2
				},
				new BankAccount
				{
					ID = 2,
					IBAN = "BG71IORT80944884276632",
					BeneficiaryName = "Stiliqn Robinov",
					StripeInfo = "stiliqnstraip",
					PaymentMethodID = 1

				},

				new BankAccount
				{
					ID = 3,
					IBAN = "BG55IORT80944219848551",
					BeneficiaryName = "Jivodar Konov",
					StripeInfo = "Lol",
					PaymentMethodID = 1

				}

			};
            db.Entity<BankAccount>().HasData(bankAccount);


			var picture = new List<Picture>()
			{
				new Picture
				{
					ID = 1,
					PictureURL = "/Users/Martin.Kolev/Pictures/azisazis",
					GalleryID = 1
				},
				new Picture
				{
					ID = 2,
					PictureURL = "/Users/Martin.Kolev/Pictures/carAzis",
					GalleryID = 1
				},

			};
            db.Entity<Picture>().HasData(picture);

			var galleries = new List<Gallery>()
			{
				new Gallery
				{
					ID = 1
				},
				new Gallery
                {
                    ID = 2
                }

            };
			db.Entity<Gallery>().HasData(galleries);


			var pages = new List<Page>()
			{
				new Page
				{
					ID = 1,
					Bio = "Kazvam se ema, obicham da pusha",
					QRLink = "link/haha/dedaznam",
					GalleryID = 1,
					UserID = 4
				},


				new Page
                {
                    ID = 2,
                    Bio = "Kazvam se ReyRey, obicham da qm qbalki",
                    QRLink = "link/haha/lol",
                    GalleryID = 2,
					UserID = 5
                }

            };
            db.Entity<Page>().HasData(pages);

			var bantables = new List<BanTable>()
			{
				new BanTable
				{
					ID = 1
				}

			};

            db.Entity<BanTable>().HasData(bantables);


			var roles = new List<Role>()
			{
				new Role
				{
					ID = 1,
					ERole = ERoles.Artist

				},


				new Role
				{
					ID = 2,
					ERole = ERoles.Admin

				},
				new Role
				{
					ID = 3,
					ERole = ERoles.Donator

				}


			};

            db.Entity<Role>().HasData(roles);



			var users = new List<User>()
			{

				new User
				{
					ID = 1,
					FirstName = "Ema",
					LastName = "Kuychukova",
					UserName = "SmokeEveryDay",
					Password = "kapachki",
					Email = "ema.kuychukova@blankfactor.com",
					PhoneNumber = "+35924492877",
					RoleID = 2

				},
				new User
				{
					ID = 2,
					FirstName = "Martin",
					LastName = "Kolev",
					UserName = "ReyRey",
					Password = "kapachki2",
					Email = "martin.kolev@blankfactor.com",
					PhoneNumber = "+35920768005",
					RoleID = 2

				},

				new User
				{
					ID = 3,
					FirstName = "Martin",
					LastName = "Konov",
					UserName = "ElbowBlock",
					Password = "kapachki3",
					Email = "martin.konov@blankfactor.com",
					PhoneNumber = "+35922649764",
					RoleID = 2

				},

				new User
				{
					ID = 4,
					FirstName = "Luben",
					LastName = "Kulishev",
					UserName = "ObichamShumaNaParite",
					Password = "Narko123",
					PhoneNumber = "+35924775508",
					Email = "luben.kulishev@blankfactor.com",
					PictureUrl = "/Users/Martin.Kolev/Pictures/luben.png",
					RoleID = 1,
					BankAccountID = 2
				},
				new User
				{
					ID = 5,
					FirstName = "Vasil",
					LastName = "Hristov",
					UserName = "vasetoHulk",
					Password = "PDA69",
					PhoneNumber = "+35924775232",
					Email = "vasil.hristov@blankfactor.com",
					PictureUrl = "/Users/Martin.Kolev/Pictures/vasil.png",
					RoleID = 1,
					BankAccountID = 1
				}

				};
        }

    }
}

