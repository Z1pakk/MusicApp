using MusicAppWithApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicAppWith.Api.Services.Services;
using MusicAppWith.Api.Services.Models;

namespace MusicAppWithApi.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index(int page=1)
        {
            ViewBag.Page = page;
            MusicService service = new MusicService();
            MusicGeneralViewModel model = service.GetMusics(page, 12);
            ViewBag.CountMusics = model.OtherInfo.CountMusics;
            return View(model.Musics);
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Music/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Music/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
