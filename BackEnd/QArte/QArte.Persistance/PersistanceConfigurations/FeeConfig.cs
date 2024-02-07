using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class FeeConfig : IEntityTypeConfiguration<Fee>
    {
        public void Configure(EntityTypeBuilder<Fee> builder)
        {
            builder.HasKey(b => b.ID);

            builder.Property(e => e.Amount).IsRequired();

        }
    }
}

