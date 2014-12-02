using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorDesignWebApp.Controllers
{
    public class SiteIndexController : Controller
    {
        // GET: SiteIndex
        public ActionResult Index()
        {
            return View();
        }
    }
}