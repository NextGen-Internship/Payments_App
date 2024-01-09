using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
	public class PictureConfig : IEntityTypeConfiguration<Picture>
	{

        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasIndex(e => e.GalleryID, "IX_Picture_GalleryID");

            builder.HasOne(e => e.Gallery)
                .WithMany(a => a.Pictures)
                .HasForeignKey(b => b.GalleryID);
        }
    }
}

