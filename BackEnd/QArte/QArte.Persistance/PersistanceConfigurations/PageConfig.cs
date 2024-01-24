using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
    public class PageConfig : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(e => e.ID);

            builder.HasIndex(e => e.QRLink).IsUnique();
            builder.Property(e => e.QRLink).IsRequired();

            builder.HasIndex(e => e.GalleryID, "IX_Page_GalleryID");

            builder.HasIndex(e => e.UserID);

            builder.HasOne(e => e.User)
                .WithMany(e=>e.Pages)
                .HasForeignKey(q => q.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Gallery)
                .WithOne()
                .HasForeignKey<Page>();
        }
    }
}

