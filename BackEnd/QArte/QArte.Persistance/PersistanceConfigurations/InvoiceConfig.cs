using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(e => e.InvoiceDate).IsRequired();
            builder.Property(e => e.TotalAmount).IsRequired();
            builder.Property(e => e.BankAccountID);

            builder.HasIndex(b => b.BankAccountID, "IX_Invoice_BankAccountID");
            builder.HasIndex(b => b.SettlementCycleID, "IX_Invoice_SettlementCycleID");

            builder.HasOne(p => p.BankAccount)
                .WithMany(i => i.Invoices)
                .HasForeignKey(j => j.BankAccountID);

            builder.HasMany(v => v.Fees);

            builder.HasOne(h => h.SettlementCycle)
                .WithOne()
                .HasForeignKey<Invoice>(u => u.SettlementCycleID);
        }
    }
}

