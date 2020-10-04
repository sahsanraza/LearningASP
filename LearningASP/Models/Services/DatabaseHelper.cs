using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningASP.DataServices;
using LearningASP.CommonCode;
using System.Data;

namespace LearningASP.Models.Services
{
    public class DatabaseHelper
    {
        private static DatabaseHelper instance;
        public static DatabaseHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHelper();
                }
                return instance;
            }

        }
        private DatabaseHelper()
        {

        }
        public void AddItem(Item item)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Insert(item);
        }
        public void RemoveItem(int id)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Execute("Delete from Item where ItemID = " + id);
        }
        public void UpdateItem(Item item)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Update(item);
        }
        public Item GetItem(int ID)
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("Item").Where("ItemID=" + ID);
            return dataContext.Fetch<Item>(Query).FirstOrDefault();
        }
        public object GetSingleObject(int ID, string table, string idName)
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From(table).Where(idName + "=" + ID);
            return dataContext.Fetch<object>(Query).FirstOrDefault();
        }
        public List<object> GetFullList(string table)
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From(table);
            return dataContext.Fetch<object>(Query).ToList();
        }
        public List<Item> GetAllItems()
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("Item");
            return dataContext.Fetch<Item>(Query).ToList();
        }
        public Customer GetCustomer(int id)
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("Customer").Where("CustomerID ="+id);
            return dataContext.Fetch<Customer>(Query).FirstOrDefault();
        }
        public List<Order> GetAllOrders()
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("Orders");
            return dataContext.Fetch<Order>(Query).ToList();
        }
        public List<OrderDetail> GetOrderItems(int id)
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("OrderDetail").Where("OrderID="+id);
            return dataContext.Fetch<OrderDetail>(Query).ToList();
        }
        public List<Customer> GetAllCustomers()
        {

            var dataContext = DataContextHelper.GetDataContext();
            var Query = PetaPoco.Sql.Builder.Select("*").From("Customer");
            return dataContext.Fetch<Customer>(Query).ToList();
        }
        public void AddCustomer(Customer cs)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Insert(cs);
        }
        public void RemoveCustomer(int id)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Execute("Delete from Customer where CustomerID = " + id);
        }
        public void UpdateCustomer(Customer cs)
        {

            var dataContext = DataContextHelper.GetDataContext();
            dataContext.Update(cs);
        }
    }
}