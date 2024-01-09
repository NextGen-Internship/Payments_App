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

            builder.HasOne(e => e.Gallery)
                .WithOne()
                .HasForeignKey<Page>();
        }
    }
}

