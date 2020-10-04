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
                OrderViewModel obj = new OrderViewModel();
                obj.OrderID = ord.OrderID;
                obj.OrderDate = ord.OrderDate;
                obj.TotalPrice = ord.TotalPrice;
                obj.Description = ord.Description;
                obj.Status = ord.Status;
                Customer cs = DatabaseHelper.Instance.GetCustomer((int)ord.CustomerID);
                obj.CustomerName = cs.CustomerName;

                List<OrderDetail> items = DatabaseHelper.Instance.GetOrderItems(ord.OrderID);
                foreach (OrderDetail odItem in items)
                {
                    obj.Items.Add(odItem);
                }
                OrderDetailInfo.Add(obj);
            }
            return View(OrderDetailInfo);
        }
    }
}