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
                    UserID = _userId,
                    ThreadTitle = model.ThreadTitle,
                    ThreadContent = model.ThreadContent,
                    ThreadPhoto = model.ThreadPhoto,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MessageBoards.Add(entity);
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
                        .MessageBoards
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
    }
}
