using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
            builder.HasKey(k => k.ID);

            builder.Property(f => f.FirstName).IsRequired();
            builder.Property(l => l.LastName).IsRequired();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.Property(g => g.isBanned).IsRequired();
            builder.Property(h => h.StripeAccountID).IsRequired();
            builder.Property(i => i.Country).IsRequired();
            builder.Property(g => g.address).IsRequired();
            builder.Property(h => h.PostalCode).IsRequired();
            builder.Property(i => i.City).IsRequired();

            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.UserName).IsUnique();

			builder.HasIndex(e => e.BankAccountID, "IX_Artist_BankAccountID");

			builder.HasIndex(e => e.RoleID, "IX_Artist_RoleID");

            builder.HasIndex(e => e.SettlementCycleID, "IX_Artist_SettlementCycleID");


            builder.HasOne(a => a.Role)
                .WithMany(b => b.Users).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(c => c.RoleID);


            builder.HasOne(a => a.SettlementCycle)
                .WithOne()
                .HasForeignKey<User>(c => c.SettlementCycleID);



            builder.HasOne(e => e.BankAccount)
				.WithOne()
				.HasForeignKey<User>(f => f.BankAccountID);


        }
		
	}
}

