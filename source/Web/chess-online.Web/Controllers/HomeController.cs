

namespace chess_online.Web.Controllers
{
    using chess_online.Models.UserModels;
    using Models;
    using Data;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;


    public class HomeController : Controller
    {
        private IChessOnlineData data;

        public HomeController()
        {
            this.data = new ChessOnlineData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Welcome(WelcomeViewModel model)
        {
            data.Players.Add(new Player
            {
                DisplayName = model.NickName,
                Rating = 1500,
                ApplicationUserId = User.Identity.GetUserId()
            });
            data.SaveChanges();
            HttpContext.Session["nickName"] = model.NickName;
            return RedirectToAction("Index");
            
        }
    }
}