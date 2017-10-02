using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP306_ONLINE_ORDER_LAB2.Models;

namespace COMP306_ONLINE_ORDER_LAB2.Controllers
{
    public class LoginController:Controller
    {
        public ActionResult Index()
        {
           
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            using (OnlineShopEntities db = new OnlineShopEntities())
            {
                var usr = db.Customers.Where(u => u.FirstName == customer.FirstName && u.LastName == customer.LastName)
                    .FirstOrDefault();
                if (usr != null)
                {
                    Session["UserId"] = usr.CustomerId.ToString();
                    Session["FirstName"] = usr.FirstName;
                    return RedirectToAction("LoggedIn",new{id=usr.CustomerId});
                }
                else
                {
                    ModelState.AddModelError("","user name not found.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn(int? id)
        {
            Customer customer;
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (OnlineShopEntities db = new OnlineShopEntities())
                {
                    customer = db.Customers.Find(id);
                }
                
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }

}