using PlakStoreCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStore.Model.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            ısActive = true;
            OrderDetails = new HashSet<OrderDetail>();
        }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
