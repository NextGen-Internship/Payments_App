using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
	public class AdminConfig : IEntityTypeConfiguration<Admin>
	{

        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasIndex(e => e.RoleID, "IX_Admin_RoleID");
            builder.Property(e => e.Role).IsRequired();

            builder.HasOne(a => a.Role)
                .WithMany(b => b.Admins)
                .HasForeignKey(c => c.RoleID);

        }
    }
}

