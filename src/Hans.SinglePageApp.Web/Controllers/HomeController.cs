using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hans.SinglePageApp.Core.Domains;
using Hans.SinglePageApp.Core.Repositories;

namespace Hans.SinglePageApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IRepository<Product> ProductRepository { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
