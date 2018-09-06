using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using TrashCollector_Project.Models;
using System;

namespace TrashCollector_Project.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employee employee = db.Employee.Find(id);
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string id)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                Employee employee = new Employee()
                {
                    ApplicationUserId = id,
                    Name = collection["Name"],
                    Zipcode = Convert.ToInt32(collection["Zipcode"]),
                };
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employee", new { id = employee.Id });
            }
            catch
            {
                return View();
            }
        }
    }
}
