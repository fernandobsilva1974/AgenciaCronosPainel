using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaCronosPainel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Servicos()
        {
            return RedirectToAction("Index", "Servicos");
        }

        public ActionResult Posts()
        {
            return RedirectToAction("Index", "Posts");
        }

        public ActionResult IntegrantesEquipe()
        {
            return RedirectToAction("Index", "Integrantes");
        }
    }
}