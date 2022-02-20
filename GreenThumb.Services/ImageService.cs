using GreenThumb.Data;
using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class ImageService
    {
        private readonly Guid _userId;

        public ImageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateImage(ImageModel model)
        {
            var entity =
                new Images()
                {
                    OwnerGUID = _userId,
                    ImageData = model.ImageData
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Images.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteImagesForUser()
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Images
                            .ToList();

                    foreach (var image in entity)
                    {
                        ctx.Images.Remove(image);
                    }

                    return ctx.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
        public ImageModel GetLatestImageForUser()
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Images
                            .First(e => e.OwnerGUID == _userId);

                    return
                        new ImageModel
                        {
                            ImageID = entity.ImageID,
                            OwnerGUID = entity.OwnerGUID,
                            ImageData = entity.ImageData
                        };
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
