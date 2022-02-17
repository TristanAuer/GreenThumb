using GreenThumb.Data;
using GreenThumb.Models.MessageBoard;
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
                    ThreadId = Guid.NewGuid(),
                    UserID = _userId,
                    ThreadTitle = model.ThreadTitle,
                    ThreadContent = model.ThreadContent,
                    ThreadPhoto = model.ThreadPhoto,
                    CreatedUtc = DateTimeOffset.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MessageBoard.Add(entity);
                return ctx.SaveChanges() == 1;
            }
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

        //UpdateMessageboard
        public bool UpdateMessageBoard(MessageBoardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .MessageBoard
                    .Single(e => e.ThreadId == model.ThreadId && e.UserID == _userId);
                //entity.ThreadId = model.ThreadId;
                entity.ThreadContent = model.ThreadContent;
                entity.ThreadTitle = model.ThreadTitle;
                entity.ThreadPhoto = model.ThreadPhoto;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        //Get Messages
        public IEnumerable<MessageBoardList> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MessageBoard
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                            new MessageBoardList
                            {
                                ThreadId = e.ThreadId,
                                ThreadTitle = e.ThreadTitle,
                                ThreadContent = e.ThreadContent,
                                ThreadPhoto = e.ThreadPhoto,
                                Content = e.Content,
                                CreatedUtc = e.CreatedUtc,

                            }
                        );
                return query.ToArray();
            }
        }

        //Get Messages by Id
        public MessageBoardDetail GetByThreadId(Guid Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MessageBoard
                        .Single(e => e.ThreadId == Id && e.UserID == _userId);
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
        public bool DeleteMessageBoard(Guid ThreadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .MessageBoard
                    .Single(e => e.ThreadId == ThreadId && e.UserID == _userId);
                ctx.MessageBoard.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
