using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WCFClient.EmployeeReference;

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

        public void AddEmployee(string name, DateTime hiredate, decimal salary, string deptname, string address)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            esc.AddEmployee(name, hiredate, salary, deptname, address);
        }

        public void DelEmployee(int id)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            esc.DelEmployee(id);
        }

        public void EditEmployee(int id, string name, DateTime hiredate, decimal salary, string deptname, string address)
        {
            EmployeeServiceClient esc = new EmployeeServiceClient();
            EmployeeEnt e = new EmployeeEnt();
            e.GetType().GetProperties();
            esc.EditEmployee(id, name, hiredate, salary, deptname, address);
        }
    }
}