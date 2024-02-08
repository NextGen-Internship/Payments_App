using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasIndex(e => e.PaymentMethodID, "IX_BankAccount_PaymentMethodID");

            builder.Property(e => e.PaymentMethodID).IsRequired();

            builder.Property(s => s.IBAN).IsRequired();

            builder.HasIndex(e => e.IBAN);
        }
    }
}

