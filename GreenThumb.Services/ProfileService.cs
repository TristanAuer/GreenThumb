using GreenThumb.Data;
using GreenThumb.Models;
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
        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile()
                {
                    UserName = model.UserName,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profile.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //public ProfileDetail GetCurrentMessage()
        //{
        //    return GetByGUID(_userId);
        //}


        public bool UpdateProfile(ProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .Profile
                    .Single(e => e.ProfileId == model.ProfileId);

                entity.UserName = model.UserName;
                entity.UserPhoto = model.UserPhoto;
                entity.CreatedUtc = model.CreatedUtc;
                        entity.CreatedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProfileList> GetProfile()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profile
                        .Select(
                            e =>
                            new ProfileList
                            {
                                ProfileId = e.ProfileId,
                                UserName = e.UserName,
                                UserPhoto = e.UserPhoto,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        public ProfileDetail GetCurrentMessage()
        {
            return GetByProfileGUID(_userId);
        }

        public ProfileDetail GetByProfileGUID(Guid guid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Profile.Any(e => e.OwnerGUID == guid))
                {
                    return null;
                }
                var entity = ctx
                    .Profile
                    .Single(e => e.OwnerGUID == guid);
                return
                    new ProfileDetail
                    {
                        ProfileId = entity.ProfileId,
                        UserName = entity.UserName,
                        UserPhoto = entity.UserPhoto,
                        CreatedUtc = entity.CreatedUtc
                    };

            }
        }

        public ProfileDetail GetByProfileId(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Profile.Any(e => e.ProfileId == Id))
                {
                    return null;
                }
                var entity =
                    ctx
                        .Profile
                        .Single(e => e.ProfileId == Id);
                return new ProfileDetail
                {
                    ProfileId = entity.ProfileId,
                    UserName = entity.UserName,
                    UserPhoto = entity.UserPhoto,
                    CreatedUtc = entity.CreatedUtc

                };

            }
        }

        public bool DeleteProfile(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Profile
                    .Single(e => e.ProfileId == Id);
                ctx.Profile.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

