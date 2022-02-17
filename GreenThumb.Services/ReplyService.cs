using GreenThumb.Data;
using GreenThumb.Models.ReplyMB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyMBCreate model)
        {

            var entity =
                new ReplyMB()
                {
                    ReplyId = model.ReplyId,
                    UserID = _userId,
                    Reply = model.Reply,
                    ReplyPhoto = model.ReplyPhoto, 
                    CreatedUtc = DateTimeOffset.Now,
                    ThreadId = model.ThreadId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ReplyMB.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyMBList> GetReplyByThreadId(Guid ThreadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ReplyMB
                        .Where(e => e.ThreadId == ThreadId)
                        .Select(
                        e =>
                        new ReplyMBList
                        {
                        ThreadId = e.ThreadId,
                        Reply = e.Reply,
                        ReplyId = e.ReplyId,
                        //ReplyPhoto = e.ReplyPhoto,
                        CreatedUtc = e.CreatedUtc,
                        });
                return query.ToArray();
                   
            }
        }
    }
}
