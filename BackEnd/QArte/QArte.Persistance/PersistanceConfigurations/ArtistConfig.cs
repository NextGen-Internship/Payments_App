using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
	public class ArtistConfig : IEntityTypeConfiguration<Artist>
	{
		public void Configure(EntityTypeBuilder<Artist> builder)
		{
			builder.HasIndex(e => e.BanID, "IX_Artist_BanID").IsUnique();

			builder.HasIndex(e => e.BankAccountID, "IX_Artist_BankAccountID");

			builder.HasIndex(e => e.RoleID, "IX_Artist_RoleID");


			builder.HasOne(a => a.Role)
				.WithMany(b => b.Artists)
				.HasForeignKey(c => c.RoleID);


			builder.HasOne(a => a.Ban)
				.WithOne()
				.HasForeignKey<Artist>(c => c.BanID);
			


			builder.HasOne(e => e.BankAccount)
				.WithOne()
				.HasForeignKey<Artist>(f => f.BankAccountID);


        }
		
	}
}

