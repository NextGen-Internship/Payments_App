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
            builder.Property(e => e.PaymentMethods).IsRequired();

            builder.HasIndex(a => a.UserID, "IX_PaymentMethod_UserID");

            builder.HasOne(u => u.User)
                .WithOne()
                .HasForeignKey<PaymentMethod>(v => v.UserID);
        }
    }
}

