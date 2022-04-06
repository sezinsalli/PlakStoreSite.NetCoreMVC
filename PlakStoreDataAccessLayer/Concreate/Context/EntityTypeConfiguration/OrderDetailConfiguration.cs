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
    class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
       
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(a => new { a.AlbumID, a.OrderID });

            builder.Ignore(a => a.TotalPrice);
        }
    }
}
