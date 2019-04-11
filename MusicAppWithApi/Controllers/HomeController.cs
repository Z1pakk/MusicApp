using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicAppWithApi.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //Вывод страницы "О нас"
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
    }
}