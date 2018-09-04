using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TrashCollector_Project.Models;
using System;

namespace TrashCollector_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Customer details = db.Customer.SingleOrDefault(identity => identity.Id == id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string id)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                Customer customer = new Customer()
                {
                    ApplicationUserId = id,
                    Name = collection["Name"],
                    Address = collection["Address"],
                    Zipcode = Convert.ToInt32(collection["Zipcode"]),
                    Schedule = Convert.ToDateTime(collection["PickUp"])
                };
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customer", null);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreatePickUp(Customer customer)
        {
            return View();
        }
    }
}
