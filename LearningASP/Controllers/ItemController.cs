using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningASP.Models.Services;
using LearningASP.DataServices;
using LearningASP.CommonCode;

namespace LearningASP.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            List<Item> list = DatabaseHelper.Instance.GetAllItems();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (item != null)
            {
                DatabaseHelper.Instance.AddItem(item);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Item item = DatabaseHelper.Instance.GetItem(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            DatabaseHelper.Instance.UpdateItem(item);
            return RedirectToAction("Index");
        }
        //public ActionResult Delete()
        //{
        //    return View();
        //}
        public ActionResult Delete(int Id)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                DatabaseHelper.Instance.RemoveItem(Id);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}