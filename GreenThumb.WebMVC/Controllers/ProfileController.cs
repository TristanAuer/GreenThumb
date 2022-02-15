using GreenThumb.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
       
        public ActionResult Index()
        {
            var model = new ProfileList[0];
            return View(model);
        }
        // GET: Profile
        public ActionResult Create()
        {
            return View();
        }
    }
}