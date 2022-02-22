using GreenThumb.Data;
using GreenThumb.Models;

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class MessageBoardService
    {
        private readonly Guid _userId;
        public MessageBoardService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMessageBoard(MessageBoardCreate model)
        {
            var entity =
                new MessageBoard()
                {
                    //ThreadId = int.(),
                    ThreadTitle = model.ThreadTitle,
                    ThreadContent = model.ThreadContent,
                    //ThreadPhoto = CreateDefaultImageModel().ImageData,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MessageBoard.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //UpdateMessageboard
        public bool UpdateMessageBoard(MessageBoardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                    .MessageBoard
                    .Single(e => e.ThreadId == model.ThreadId);
                entity.ThreadId = model.ThreadId;
                entity.ThreadContent = model.ThreadContent;
                entity.ThreadTitle = model.ThreadTitle;
                entity.ThreadPhoto = model.ThreadPhoto;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        //public bool CreateProfile(ProfileCreate model)
        //{
        //    throw new NotImplementedException();
        //}


        //Get Current messages
        public IEnumerable<MessageBoardList> GetCurrentMessage()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query = ctx
                    .MessageBoard
                    .Where(e => e.OwnerGUID == _userId)
                    .OrderBy(p => p.CreatedUtc)
                    .Select(
                      e =>
                    new MessageBoardList
                    {
                        ThreadId = e.ThreadId,
                        ThreadTitle = e.ThreadTitle,
                        ThreadContent = e.ThreadContent,
                        //ThreadPhoto = (entity.ThreadPhoto == null || entity.ThreadPhoto.Length ==0) ? CreateImagemodel() 
                    });
                return query.ToArray();
            }
        }

        public MessageBoardDetail GetByThreadGUID(Guid guid)
        {
            using(var ctx = new ApplicationDbContext())
            {
                if(!ctx.MessageBoard.Any(e => e.OwnerGUID == guid))
                {
                    return null;
                }
                var entity = ctx
                    .MessageBoard
                    .Single(e => e.OwnerGUID == guid);
                return
                    new MessageBoardDetail
                    {
                        ThreadId = entity.ThreadId,
                        ThreadTitle = entity.ThreadTitle,
                        ThreadContent = entity.ThreadContent,
                        //ThreadPhoto = (entity.ThreadPhoto == null || entity.ThreadPhoto.Length ==0) ? CreateImagemodel() 
                    };

            }
        }


        //Get Messages by Id
        public MessageBoardDetail GetByThreadId(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.MessageBoard.Any(e => e.ThreadId == Id))
                {
                    return null;
                }
                var entity =
                    ctx
                        .MessageBoard
                        .Single(e => e.ThreadId == Id);
                return new MessageBoardDetail
                {
                    ThreadId = entity.ThreadId,
                    ThreadTitle = entity.ThreadTitle,
                    ThreadContent = entity.ThreadContent,
                    ThreadPhoto = entity.ThreadPhoto,
                    ModifiedUtc = entity.ModifiedUtc,
                    CreatedUtc = entity.CreatedUtc
                };

            }
        }

        //delete
        public bool DeleteMessageBoard(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .MessageBoard
                    .Single(e => e.ThreadId == Id);
                ctx.MessageBoard.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageBoardList> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MessageBoard
                        .Select(
                            e =>
                            new MessageBoardList
                            {
                                ThreadId = e.ThreadId,
                                ThreadTitle = e.ThreadTitle,
                                ThreadContent = e.ThreadContent,
                                ThreadPhoto = e.ThreadPhoto,
                                //Content = e.Content,
                                CreatedUtc = e.CreatedUtc,

                            }
                        );
                return query.ToArray();
            }
        }


        //public IEnumerable<MessageBoardList> GetThreadSearchString(string input)
        //{

        //    using (var ctx = new ApplicationDbContext())
        //    {

        //        // If the user has a Person associated with them, filter out any Friends from the list of Strangers
        //        if (ctx.MessageBoard.Any(p => p.OwnerGUID == _userId) && ctx.ReplyMB.Any(f => f.OwnerGUID == _userId))
        //        {
        //            var Thread = ctx.MessageBoard.Where(e => e.OwnerGUID != _userId &&
        //                                                !ctx.ReplyMB.Any(f => f.OwnerGUID == _userId && f.ReplyId == e.ThreadId) 
        //                                                && ( e.ModifiedUtc)

        //                                        .DateTime latestDate = myCollection.Where(r => r.ExpirationDate.HasValue)
        //                          .Max(r => r.ExpirationDate)
        //                                        .Select(e =>
        //                                                    new PersonListItem_Stranger
        //                                                    {
        //                                                        PersonID = e.PersonID,
        //                                                        FullName = e.FirstName + " " + e.LastName,
        //                                                        ProfilePicture = e.ProfilePicture
        //                                                    }
        //                                        );

        //            return strangers.ToArray();
        //        }

        //        var query = ctx.People.Where(e => e.PersonGUID != _userId &&
        //                                    (e.FirstName.ToLower().Contains(input.ToLower()) || e.LastName.ToLower().Contains(input.ToLower())))
        //                                .OrderBy(f => f.LastName)
        //                                .ThenBy(f => f.FirstName)
        //                                .Select(e =>
        //                                        new PersonListItem_Stranger
        //                                        {
        //                                            PersonID = e.PersonID,
        //                                            FullName = e.FirstName + " " + e.LastName,
        //                                            ProfilePicture = e.ProfilePicture
        //                                        }
        //                                );

        //        return query.ToArray();
        //    }
        //}
        private ImageService CreateImageService()
        {
            var service = new ImageService(_userId);
            return service;
        }


        private ImageModel CreateImageModelForBytes(byte[] input)
        {
            var service = CreateImageService();

            service.DeleteImagesForUser();

            var model = new ImageModel();
            model.ImageData = input;
            model.OwnerGUID = _userId;

            if (!service.CreateImage(model))
                return null;

            return service.GetLatestImageForUser();
        }

        //private readonly ApplicationDbContext db = new ApplicationDbContext();
        //public int UploadImageInDataBase(HttpPostedFileBase file, ContentViewModel contentViewModel)
        //{
        //    contentViewModel.Image = ConvertToBytes(file);
        //    var Content = new Content
        //    {
        //        Title = contentViewModel.Title,
        //        Description = contentViewModel.Description,
        //        Contents = contentViewModel.Contents,
        //        Image = contentViewModel.Image
        //    };
        //    db.Contents.Add(Content);
        //    int i = db.SaveChanges();
        //    if (i == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        //public byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    byte[] imageBytes = null;
        //    BinaryReader reader = new BinaryReader(image.InputStream);
        //    imageBytes = reader.ReadBytes((int)image.ContentLength);
        //    return imageBytes;
        //}
    }
}
