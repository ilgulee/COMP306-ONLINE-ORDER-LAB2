using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using COMP306_ONLINE_ORDER_LAB2.Models;

namespace COMP306_ONLINE_ORDER_LAB2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private OnlineShopEntities db=new OnlineShopEntities();

        public ShoppingCartController()
        {
            
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                Cart=GetCart(),
                ReturnUrl = returnUrl
            });
        }

        private ShoppingCartModel GetCart()
        {
            ShoppingCartModel cart = (ShoppingCartModel) Session["Cart"];
            if (cart == null)
            {
                cart=new ShoppingCartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = db.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                GetCart().AddItem(product,1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            GetCart().RemoveItem(productId);
            return RedirectToAction("Index", new {returnUrl});
        }

       
    }
}