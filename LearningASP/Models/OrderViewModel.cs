using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningASP.DataServices;

namespace LearningASP.Models
{
    public class OrderViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<OrderDetail> Items { get; set; }
    }
}