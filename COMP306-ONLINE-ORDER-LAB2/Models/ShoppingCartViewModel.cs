using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP306_ONLINE_ORDER_LAB2.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartModel Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}