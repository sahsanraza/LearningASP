using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningASP.DataServices;
using LearningASP.CommonCode;
using LearningASP.Models.Services;
using LearningASP.Models;

namespace LearningASP.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = DatabaseHelper.Instance.GetAllOrders();
            List<OrderViewModel> OrderDetailInfo = new List<OrderViewModel>();
            foreach (Order ord in orders)
            {
                OrderViewModel ovm = new OrderViewModel();
                ovm.OrderID = ord.OrderID;
                ovm.OrderDate = ord.OrderDate;
                ovm.TotalPrice = ord.TotalPrice;
                ovm.Quantity = ord.Quantity;
                ovm.Description = ord.Description;
                ovm.Status = ord.Status;
                Customer cs = DatabaseHelper.Instance.GetCustomer((int)ord.CustomerID);
                ovm.CustomerName = cs.CustomerName;
                ovm.CustomerID = cs.CustomerID;
                List<OrderDetail> items=DatabaseHelper.Instance.GetOrderItems(ord.OrderID);
                ovm.Items = new List<OrderDetail>();
                foreach (OrderDetail odItem in items)
                {
                    ovm.Items.Add(odItem);
                }
                OrderDetailInfo.Add(ovm);
            }
            return View(OrderDetailInfo);
        }
        public ActionResult OrderDetail(OrderViewModel ovm)
        {
            if (ovm == null)
            {
                return RedirectToAction("Index");
            }
            return View(ovm);
        }

    }
}