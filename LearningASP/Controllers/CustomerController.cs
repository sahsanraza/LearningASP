using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningASP.DataServices;
using LearningASP.Models.Services;
using LearningASP.Models;

namespace LearningASP.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            List<Customer> customers = DatabaseHelper.Instance.GetAllCustomers();
            return View(customers);
        }
        public ActionResult Edit(int id)
        {
            Customer cs = DatabaseHelper.Instance.GetCustomer(id);
            return View(cs);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (customer != null)
            {
                DatabaseHelper.Instance.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Delete(Customer customer)
        {
            if (customer != null)
            {
                DatabaseHelper.Instance.RemoveCustomer(customer.CustomerID);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (customer != null)
            {
                DatabaseHelper.Instance.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}