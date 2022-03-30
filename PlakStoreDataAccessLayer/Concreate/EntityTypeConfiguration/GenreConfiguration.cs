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
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID).UseIdentityColumn();

            builder.Property(a => a.Name)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(a => a.Description)
                    .HasMaxLength(250)
                    .IsRequired();
        }
    }
}
