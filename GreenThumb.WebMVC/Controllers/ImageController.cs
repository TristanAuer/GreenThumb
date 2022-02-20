using GreenThumb.Models;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public bool _isProfilePicture { get; set; }
        private Guid _userGUID;

        public ImageController()
        {
            _isProfilePicture = true;

            if (User != null)
            {
                try { _userGUID = Guid.Parse(User.Identity.GetUserId()); } catch { }
            }
        }
        public ImageController(Guid userGUID)
        {
            _isProfilePicture = true;
            _userGUID = userGUID;
        }

        //[HttpGet]
        //public JsonResult CreateRandomImageJSON(bool isPerson)
        //{
        //    ImageModel model = CreateRandomImage(isPerson);
        //    if (model is null)
        //        return Json(null, JsonRequestBehavior.AllowGet);

        //    var imageSrc = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(model.ImageData));
        //    var newModel = new { model.ImageID, imageSrc };

        //    var jsonModel = Json(newModel, JsonRequestBehavior.AllowGet);

        //    return jsonModel;
        //}

        //public ImageModel CreateRandomImage(bool isPerson)
        //{
        //    // Get service and clear all images for this user (meant to be temporary)
        //    var service = CreateImageService();
        //    if (service is null)
        //        return null;

        //    service.DeleteImagesForUser();

        //    if (!service.CreateDefaultImage(isPerson))
        //    {
        //        return null;
        //    }
        //    return service.GetLatestImageForUser();
        //}

        //public ImageModel CreateRandomImage()
        //{
        //    // Get service and clear all images for this user (meant to be temporary)
        //    var service = CreateImageService();
        //    return service.CreateAndReturnRandomImage(_isProfilePicture);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("UploadImage")]
        //public JsonResult UploadImage()
        //{
        //    HttpPostedFileBase file = Request.Files[0]; //Uploaded file

        //    try
        //    {
        //        // Image was uploaded and doesn't exist in database yet
        //        if (file != null && file.ContentLength != 0)
        //        {
        //            var imageService = CreateImageService();
        //            if (imageService is null)
        //                return Json(new { successful = false }, JsonRequestBehavior.AllowGet);

        //            bool successful = imageService.CreateUploadedImage(ConvertToBytes(file));

        //            return Json(new { successful = true }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch { }

        //    return Json(new { successful = false }, JsonRequestBehavior.AllowGet);
        //}

        public ImageModel GetLatestImageForUser()
        {
            var service = CreateImageService();
            if (service is null)
                return null;

            return service.GetLatestImageForUser();
        }

        public ImageModel GetLatestImageForUser(Guid userID)
        {
            var service = CreateImageService(userID);
            if (service is null)
                return null;

            return service.GetLatestImageForUser();
        }

        //public ImageModel GetImageForID(int id)
        //{
        //    var service = CreateImageService();
        //    if (service is null)
        //        return null;

        //    return service.GetImageByID(id);
        //}
        //public ImageModel GetImageForID(int id, Guid userID)
        //{
        //    var service = CreateImageService(userID);
        //    if (service is null)
        //        return null;

        //    return service.GetImageByID(id);
        //}

        private ImageService CreateImageService()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            Guid userId;
            try
            {
                if (User != null)
                {
                    userId = Guid.Parse(User.Identity.GetUserId());
                }
                else
                {
                    userId = _userGUID;
                }
            }
            catch
            {
                userId = _userGUID;
            }

            var service = new ImageService(userId);
            return service;
        }

        private ImageService CreateImageService(Guid userID)
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var service = new ImageService(userID);
            return service;
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            using (var reader = new BinaryReader(image.InputStream))
            {
                return reader.ReadBytes(image.ContentLength);
            }
        }
    }
}