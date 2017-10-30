using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeGridTesti.Models;

namespace TreeGridTesti.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abc()
        {
            return View();
        }

        public JsonResult GetCategories()
        {
            try
            {
                using (TestDbEntities db = new TestDbEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var kategoriler = db.Categories.Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        RootId = s.RootId
                    }).ToList();
                    return Json(kategoriler, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                var hata = e.InnerException.Message;
                return Json(hata, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetList()
        {
            try
            {
                using (TestDbEntities db = new TestDbEntities())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    var kategoriler = db.Categories.Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        RootId = s.RootId
                    }).ToList();
                    return Json(new { data = kategoriler }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                var hata = e.InnerException.Message;
                return Json(hata, JsonRequestBehavior.AllowGet);
            }
        }
    }
}