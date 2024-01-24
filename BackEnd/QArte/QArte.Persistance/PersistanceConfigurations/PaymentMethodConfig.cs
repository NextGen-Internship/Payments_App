using System;
using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(k => k.ID);
            builder.Property(e => e.PaymentMethods).IsRequired();

        }
    }
}

