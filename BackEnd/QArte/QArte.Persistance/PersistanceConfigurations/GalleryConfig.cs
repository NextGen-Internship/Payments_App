using System;
using QArte.Persistance.PersistanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QArte.Persistance.PersistanceConfigurations
{
	public class GalleryConfig : IEntityTypeConfiguration<Gallery>
	{

        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.HasKey(e => e.ID);
        }
    }
}

