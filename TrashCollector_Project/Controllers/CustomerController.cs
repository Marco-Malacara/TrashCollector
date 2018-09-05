using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TrashCollector_Project.Models;
using System;
using Microsoft.AspNet.Identity;

namespace TrashCollector_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Customer customer = db.Customer.Find(id);
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            double monthlySubscription = 20.00;
            double specialPickUpCharge = 12.00;
            ApplicationDbContext db = new ApplicationDbContext();
            Customer details = db.Customer.SingleOrDefault(identity => identity.Id == id);
            if (details == null)
            {
                return HttpNotFound();
            }
            if (details.Schedule != null && details.SpecialPickUp == null)
            {
                details.Debt = Convert.ToString("$" + monthlySubscription);
                return View(details);
            }
            else if (details.SpecialPickUp != null && details.Schedule != null && details.Start == null)
            {
                double total = monthlySubscription + specialPickUpCharge;
                details.Debt = Convert.ToString("$" + total);
                return View(details);
            }
            else
            {
                return View(details);
            }
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
                    State = collection["State"],
                    City = collection["City"],
                    Address = collection["Address"],
                    Zipcode = Convert.ToInt32(collection["Zipcode"]),
                    Schedule = Convert.ToDateTime(collection["Schedule"])
                };
                db.Customer.Add(customer);
                db.SaveChanges();
                SetUpWeeklyPickUp(id);
                return RedirectToAction("Index", "Customer", new { id = customer.Id});
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SetUpWeeklyPickUp(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Customer customer = db.Customer.SingleOrDefault(identity => identity.ApplicationUserId == id);
            SetUpWeeklyPickUp(customer);
            return View();
        }
        [HttpPost]
        public ActionResult SetUpWeeklyPickUp(Customer customer)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Pickup pickup;
            if (customer.PickupId == null) {
                pickup = new Pickup();
                DateTime? date = customer.Schedule;
                pickup.WeekOne = date;
                pickup.WeekTwo = date.Value.AddDays(7);
                pickup.WeekThree = date.Value.AddDays(14);
                pickup.WeekFour = date.Value.AddDays(21);
                db.Pickup.Add(pickup);
                customer.PickupId = pickup.Id;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Customer", new { id = customer.Id});
            }
            else if (customer.PickupId != null)
            {
                if (customer.Start != null)
                {
                    customer.Start = null;
                    customer.End = null;
                }
                int? pickUpId = customer.PickupId;
                pickup = db.Pickup.Find(pickUpId);
                DateTime? date = customer.Schedule;
                pickup.WeekOne = date;
                pickup.WeekTwo = date.Value.AddDays(7);
                pickup.WeekThree = date.Value.AddDays(14);
                pickup.WeekFour = date.Value.AddDays(21);
                db.Entry(pickup).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Customer",  new { id = customer.Id});
            }
            else
            {
                return RedirectToAction("EditPickUp", "Customer", customer);
            }
        }
        public ActionResult TemporaryPickUp(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult TemporaryPickUp(int? id, FormCollection collection)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Customer customer = db.Customer.Find(id);
            Pickup pickup;
            try
            {
                int? pickUpId = customer.PickupId;
                pickup = db.Pickup.Find(pickUpId);
                customer.Start = Convert.ToDateTime(collection["Start"]);
                customer.End = Convert.ToDateTime(collection["End"]);
                DateTime? startDate = customer.Start;
                DateTime? endDate = customer.End;
                customer.Schedule = null;
                pickup.WeekOne = null;
                pickup.WeekTwo = null;
                pickup.WeekThree = null;
                pickup.WeekFour = null;
                pickup.StartPickUp = startDate;
                pickup.EndPickUp = endDate;
                db.Entry(pickup).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Customer", new { id = customer.Id });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SpecialPickUp(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult SpecialPickUp(int? id, FormCollection collection)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                Customer customer = db.Customer.Find(id);
                customer.SpecialPickUp = Convert.ToDateTime(collection["SpecialPickUp"]);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Customer", new { id = customer.Id });
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Edit/5
        public ActionResult EditPickUp(int? id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditPickUp(int? id, FormCollection collection)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                Customer customer = db.Customer.Find(id);
                customer.Schedule = Convert.ToDateTime(collection["Schedule"]);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                SetUpWeeklyPickUp(customer.ApplicationUserId);
                return RedirectToAction("Index", "Customer", new { id = customer.Id });
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
