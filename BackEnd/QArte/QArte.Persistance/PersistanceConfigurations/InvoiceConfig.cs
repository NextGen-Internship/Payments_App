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
            builder.Property(e => e.BankAccountID).IsRequired();
            builder.Property(f => f.BankAccountID).IsRequired();

            builder.HasIndex(b => b.BankAccountID, "IX_Invoice_UserID");
            builder.HasIndex(b => b.FeeID, "IX_Invoice_FeeID");

            builder.HasOne(p => p.BankAccount)
                .WithMany(i => i.Invoices)
                .HasForeignKey(j => j.BankAccountID);

            builder.HasOne(q => q.Fee)
                .WithOne()
                .HasForeignKey<Invoice>(r => r.FeeID);
        }
    }
}

