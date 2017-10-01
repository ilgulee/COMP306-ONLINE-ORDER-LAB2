using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMP306_ONLINE_ORDER_LAB2.Models;
using System.Data.Entity;

namespace COMP306_ONLINE_ORDER_LAB2.Controllers
{
    public class RegisterController : Controller
    {
        private OnlineShopEntities db=new OnlineShopEntities();
        // GET: Register
       
        
        public ActionResult Index()
        {
            var district = db.Districts.ToList();
            var viewModel = new RegisterCustomerViewModel
            {
                District = district
            };
            return View(viewModel);
        }

        public RedirectToRouteResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }else
            {
                return RedirectToAction("Index", "Register");
            }
            
        }
    }
}