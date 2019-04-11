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
        //Выввод станицы со списком музыки
        // GET: Music
        [HttpGet]
        public ActionResult Index(string searchText,int page = 1)
        {
            //Сохранение на странице страницы пагинации и текст который ввели
            ViewBag.Page = page;
            ViewBag.SearchText = searchText;
            //Вызов метода из сервиса MusicService
            MusicService service = new MusicService();
            //Мы передаем страницу, количество для показа, текст по которому искать
            //Он возвращает нам песни в виде обьектов.
            MusicGeneralViewModel model = service.GetMusics(page, 12, searchText);

            //Проверяем небыло ли ошибки
            if (model.Error == null)
            {
                ViewBag.Error = null;
                ViewBag.CountMusics = model.OtherInfo.CountMusics;
            }
            else
            {
                ViewBag.Error = model.Error;
            }
            return View(model.Musics);
        }
        //Метод когда мы кликнем на кнопку "Поиск"
        [HttpPost]
        public ActionResult Search(int page,string text)
        {
            //Перенапрявляет на метод Index с параметрами
            return RedirectToAction("Index", new { searchText = text,page=page });
        }
    }
}
