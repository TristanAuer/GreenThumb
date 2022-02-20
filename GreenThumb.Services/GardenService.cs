using GreenThumb.Data;
using GreenThumb.Models.Garden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class GardenService
    {
        private readonly Guid _userId;
        public GardenService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGarden(GardenCreate model)
        {
            var entity =
                new GardenTable()
                {
                    GardenName = model.GardenName,
                    PlantType = model.PlantType,
                    PlantCount = model.PlantCount,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GardenTable.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public bool UpdateGarden(GardenEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .GardenTable
                    .Single(e => e.GardenId == model.GardenId);
                entity.GardenName= model.GardenName;
                entity.PlantType = model.PlantType;
                entity.PlantCount = model.PlantCount;
                //entity.PlantPhoto = model.PlantPhoto;
                entity.ModifiedUtc = DateTimeOffset.Now;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GardenList> GetGarden()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GardenTable
                        .Select(
                            e =>
                            new GardenList
                            {
                                GardenId = e.GardenId,
                                GardenName = e.GardenName,
                                PlantType = e.PlantType,
                                PlantCount = e.PlantCount,
                                CreatedUtc = e.CreatedUtc,
                                ModifiedUtc = e.ModifiedUtc,
                                PlantPhoto = e.PlantPhoto
                            }
                        );
                return query.ToArray();
            }
        }

        public GardenDetail GetCurrentMessage()
        {
            return GetByProfileGUID(_userId);
        }

        public GardenDetail GetByProfileGUID(Guid guid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Profile.Any(e => e.OwnerGUID == guid))
                {
                    return null;
                }
                var entity = ctx
                    .GardenTable
                    .Single(e => e.OwnerGUID == guid);
                return
                    new GardenDetail
                    {
                        GardenId = entity.GardenId,
                        GardenName = entity.GardenName,
                        PlantType = entity.PlantType,
                        PlantCount = entity.PlantCount,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };

            }
        }

        public GardenDetail GetByGardenId(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.GardenTable.Any(e => e.GardenId == Id))
                {
                    return null;
                }
                var entity =
                    ctx
                        .GardenTable
                        .Single(e => e.GardenId == Id);
                return new GardenDetail
                {
                    GardenId = entity.GardenId,
                    GardenName = entity.GardenName,
                    PlantType = entity.PlantType,
                    PlantCount = entity.PlantCount,
                    
                    ModifiedUtc = entity.ModifiedUtc,
                    
                };

            }
        }

        public bool DeleteGarden(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .GardenTable
                    .Single(e => e.GardenId == Id);
                ctx.GardenTable.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
