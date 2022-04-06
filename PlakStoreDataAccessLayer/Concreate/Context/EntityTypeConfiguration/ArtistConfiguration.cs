using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlakStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.Concreate.EntityTypeConfiguration
{
    class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID).UseIdentityColumn();

            builder.Property(a => a.FullName)
                .HasMaxLength(100).IsRequired();

            builder.Property(a => a.Bio)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
