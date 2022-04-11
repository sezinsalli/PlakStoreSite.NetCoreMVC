using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreViewModel.CartViewModels
{
    public class CartItem//ÜRÜN
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Price * Quantity * (1 - Discount);
            }
        }
    }
}
