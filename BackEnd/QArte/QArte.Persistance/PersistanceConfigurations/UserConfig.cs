using System;
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
        }
    }
}

