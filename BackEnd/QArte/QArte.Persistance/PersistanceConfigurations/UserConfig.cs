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

            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.UserName).IsUnique();

            builder.HasIndex(e => e.BanID, "IX_Artist_BanID").IsUnique();

			builder.HasIndex(e => e.BankAccountID, "IX_Artist_BankAccountID");

			builder.HasIndex(e => e.RoleID, "IX_Artist_RoleID");
            


            builder.HasOne(a => a.Role)
				.WithMany(b => b.Users).OnDelete(DeleteBehavior.Restrict)
				.HasForeignKey(c => c.RoleID);


			builder.HasOne(a => a.Ban)
				.WithOne()
				.HasForeignKey<User>(c => c.BanID);
			


			builder.HasOne(e => e.BankAccount)
				.WithOne()
				.HasForeignKey<User>(f => f.BankAccountID);


        }
		
	}
}

