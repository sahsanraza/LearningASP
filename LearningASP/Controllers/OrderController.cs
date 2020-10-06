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
                ovm.Quantity = ord.TotalQuantity;
                ovm.Description = ord.Description;
                ovm.Status = ord.Status;
                Customer cs = DatabaseHelper.Instance.GetCustomer((int)ord.CustomerID);
                ovm.CustomerName = cs.CustomerName;
                ovm.CustomerID = cs.CustomerID;
                List<OrderDetail> items=DatabaseHelper.Instance.GetOrderItems(ord.OrderID);
                ovm.SelectedItems = new List<OrderDetail>();
                Item it;
                foreach (OrderDetail odItem in items)
                {
                    it= DatabaseHelper.Instance.GetItem((int)odItem.ItemID);
                    odItem.ItemName = it.ItemName;
                    ovm.SelectedItems.Add(odItem);
                }
                OrderDetailInfo.Add(ovm);
            }
            return View(OrderDetailInfo);
        }
        public ActionResult Create()
        {
            OrderViewModel ovm = new OrderViewModel();
            ovm.AvailableItems = DatabaseHelper.Instance.GetAllItems();
            ovm.TotalCustomers = DatabaseHelper.Instance.GetAllCustomers();
            return View(ovm);
        }
        public ActionResult OrderDetail(int OrderID=0)
        {
            if (OrderID ==0)
            {
                return RedirectToAction("Index");
            }
            OrderViewModel ovm = new OrderViewModel();
            Order ord = DatabaseHelper.Instance.GetSelectedOrders(OrderID);
            ovm.OrderID = ord.OrderID;
            ovm.OrderDate = ord.OrderDate;
            ovm.TotalPrice = ord.TotalPrice;
            ovm.Quantity = ord.TotalQuantity;
            ovm.Description = ord.Description;
            ovm.Status = ord.Status;
            Customer cs = DatabaseHelper.Instance.GetCustomer((int)ord.CustomerID);
            ovm.CustomerName = cs.CustomerName;
            ovm.CustomerID = cs.CustomerID;
            List<OrderDetail> items = DatabaseHelper.Instance.GetOrderItems(ord.OrderID);
            ovm.SelectedItems = new List<OrderDetail>();
            Item it;
            foreach (OrderDetail odItem in items)
            {
                it = DatabaseHelper.Instance.GetItem((int)odItem.ItemID);
                odItem.ItemName = it.ItemName;
                ovm.SelectedItems.Add(odItem);
            }
            return View(ovm);
        }

    }
}