using MusicAppWith.Api.Services.Models;
using MusicAppWith.Api.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MusicAppWithApi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FinishLogin(string code, string state)
        {
            ViewBag.Code = code;
            return View("Index");
        }
        [HttpPost]
        public JsonResult FinishLogin(Credentials cred)
        {
            LoginService service = new LoginService();
            string accesToken = service.Login(cred.Code, cred.RedirectUrl);
            
            return Json(new { access_Token = accesToken }, JsonRequestBehavior.AllowGet);
        }
    }
}