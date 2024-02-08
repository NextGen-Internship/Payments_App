using System;
using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class SettlementCycleConfig : IEntityTypeConfiguration<SettlementCycle>
    {
        public void Configure(EntityTypeBuilder<SettlementCycle> builder)
        {
            builder.Property(e => e.SettlementCycles).IsRequired();
            builder.HasKey(k => k.ID);
        }
    }
}

