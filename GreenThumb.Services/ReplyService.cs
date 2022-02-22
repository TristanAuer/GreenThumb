using GreenThumb.Data;
using GreenThumb.Models;
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
                    OwnerGUID = _userId,
                    ThreadId = model.ThreadId,
                    Reply = model.Reply,
                    ReplyPhoto = model.ReplyPhoto,
                    CreatedUtc = DateTimeOffset.Now,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ReplyMB.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyMBList> ListReplyByThreadId(int ThreadId)
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
                            Reply = e.Reply,
                            ReplyId = e.ReplyId,
                            ReplyPhoto = e.ReplyPhoto,
                            CreatedUtc = e.CreatedUtc,
                        });
                return query.ToArray();

            }
        }
        public IEnumerable<ReplyMB> RecentReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                var query = ctx.ReplyMB.OrderBy(p => p.CreatedUtc);
                return query.ToArray();
            }
        }
    }
}
