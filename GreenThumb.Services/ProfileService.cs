using GreenThumb.Data;
using GreenThumb.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;
        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        /*public bool CreateProfile (ProfileCreate model)
        {
            var entity =
                new Profile()
                {
                    UserId = _userId,
                    UserPhoto = model.UserPhoto,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }*/
    }
}
