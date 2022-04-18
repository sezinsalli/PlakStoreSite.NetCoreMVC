using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakStoreViewModel.CartViewModels
{
    public class Cart//SEPET
    {
        private static Dictionary<int, CartItem> basket = new Dictionary<int, CartItem>(); 

        public List<CartItem> GetCartItems => basket.Values.ToList();//vıewde ulasmak ııcın public lıst yaptık @foreach (var item in Model.GetCartItems)
        public void Add(CartItem item)
        {
            if (basket.ContainsKey(item.ID))
            {
                //eger bu ıdlı urun daha once eklenmısse quantıty bılgısını degıstırecegım o urune gıdıpç
                basket[item.ID].Quantity += item.Quantity;
                return;
            }
            //eger eklenmemısse burada
            basket.Add(item.ID, item);
        }

        public void Update(int id, short quantity)
        {
            if (basket.ContainsKey(id))
            {
                basket[id].Quantity = quantity;
            }
        }

        public void Delete(int id)
        {
            if (basket.ContainsKey(id))
            {
                basket.Remove(id);
            }
        }

        public decimal TotalQuantity => basket.Values.Sum(a => a.Quantity);

    }
}
