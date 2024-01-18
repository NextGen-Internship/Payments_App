using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class BanTableConfig : IEntityTypeConfiguration<BanTable>
    {
        public void Configure(EntityTypeBuilder<BanTable> builder)
        {
            builder.HasKey(e => e.ID);

            builder.Property(e => e.BanID);
        }
    }
}

