using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WCFClient.EmployeeReference;
using WCFClient.Models;

namespace WCFClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employees()
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            ViewBag.employees = esc.GetAll().ToList();
            ViewBag.props = typeof(EmployeeEnt).GetProperties().Where(a => a.Name != "ExtensionData").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Employees(EmployeeModel e)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            if (ModelState.IsValid)
            {
                if (e.Id != -1)
                    EditEmployee(e.Id, e.Name, e.Hiredate, e.Salary, e.Deptname, e.Address);
                else
                    AddEmployee(e.Name, e.Hiredate, e.Salary, e.Deptname, e.Address);
                System.Diagnostics.Debug.WriteLine(e.Id);
                e = new EmployeeModel
                {
                    Address = "",
                    Deptname = "",
                    Name = "",
                    Salary = 0,
                    Id = -1
                };
            }
            ViewBag.employees = esc.GetAll().ToList();
            ViewBag.props = typeof(EmployeeEnt).GetProperties().Where(a => a.Name != "ExtensionData").ToList();
            return View(e);
        }

        private void AddEmployee(string name, DateTime hiredate, decimal salary, string deptname, string address)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            esc.AddEmployee(name, hiredate, salary, deptname, address);
        }

        public void DelEmployee(int id)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            esc.DelEmployee(id);
        }

        private void EditEmployee(int id, string name, DateTime hiredate, decimal salary, string deptname, string address)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            EmployeeEnt e = new EmployeeEnt();
            e.GetType().GetProperties();
            esc.EditEmployee(id, name, hiredate, salary, deptname, address);
        }

        public JsonResult GetDepts(string term)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            return Json(esc.GetDepts(term).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}