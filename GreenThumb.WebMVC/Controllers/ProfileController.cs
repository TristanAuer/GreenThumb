using GreenThumb.Models.Profile;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = Guid.Parse(User.Identity.GetUserId());
            //    var service = new ProfileService(userId);
            //    var model = service.GetProfile();
            //    return View(model);
            //}
            //else
            {
                var model = new ProfileList[0];
                return View(model);
            }
        }
        // GET: Profile
        public ActionResult Create()
        {
            return View();
        }

    }
}