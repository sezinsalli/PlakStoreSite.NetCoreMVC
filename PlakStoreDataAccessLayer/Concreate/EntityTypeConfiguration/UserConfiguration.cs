using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlakStore.Model.Entities;
using PlakStore.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreDataAccessLayer.Concreate.EntityTypeConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(18);

            builder.Property(a => a.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(a => a.Email)
                .IsUnique();

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Sezin",
                LastName = "Şallı",
                Email = "sezin@gmail.com",
                Password = "123",
                Address = "sezsez",
                Role = UserRole.Admin,
                ısActive = true
            });
        }
    }
}
