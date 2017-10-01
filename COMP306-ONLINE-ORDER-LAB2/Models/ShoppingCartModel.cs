using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP306_ONLINE_ORDER_LAB2.Models
{
    public class ShoppingCartModel
    {
        private List<ShoppingCartItemModel> items=new List<ShoppingCartItemModel>();

        public IEnumerable<ShoppingCartItemModel> Items
        {
            get { return items; }
        }

        public void AddItem(Product product, int quantity)
        {
            ShoppingCartItemModel item =
                items.SingleOrDefault(p => p.Product.ProductId == product.ProductId);

            if (item == null)
            {
                items.Add(new ShoppingCartItemModel
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            items.RemoveAll(l => l.Product.ProductId == productId);
        }

        public decimal GetCartTotal()
        {
            return items.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}