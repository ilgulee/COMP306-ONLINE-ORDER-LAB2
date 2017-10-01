using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP306_ONLINE_ORDER_LAB2.Models
{
    public class ShoppingCartItemModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}