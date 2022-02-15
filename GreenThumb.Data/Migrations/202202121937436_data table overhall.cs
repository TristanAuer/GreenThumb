namespace GreenThumb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatableoverhall : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageBoards",
                c => new
                    {
                        ThreadId = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        ThreadContent = c.String(nullable: false),
                        ThreadTitle = c.String(nullable: false),
                        ThreadPhoto = c.Byte(nullable: false),
                        Content = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ThreadId);
            
            CreateTable(
                "dbo.ReplyMBs",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Reply = c.String(nullable: false, maxLength: 500),
                        ReplyPhoto = c.Byte(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId);
            
            CreateTable(
                "dbo.ReplyMBMessageBoards",
                c => new
                    {
                        ReplyMB_ReplyId = c.Int(nullable: false),
                        MessageBoard_ThreadId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReplyMB_ReplyId, t.MessageBoard_ThreadId })
                .ForeignKey("dbo.ReplyMBs", t => t.ReplyMB_ReplyId, cascadeDelete: true)
                .ForeignKey("dbo.MessageBoards", t => t.MessageBoard_ThreadId, cascadeDelete: true)
                .Index(t => t.ReplyMB_ReplyId)
                .Index(t => t.MessageBoard_ThreadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReplyMBMessageBoards", "MessageBoard_ThreadId", "dbo.MessageBoards");
            DropForeignKey("dbo.ReplyMBMessageBoards", "ReplyMB_ReplyId", "dbo.ReplyMBs");
            DropIndex("dbo.ReplyMBMessageBoards", new[] { "MessageBoard_ThreadId" });
            DropIndex("dbo.ReplyMBMessageBoards", new[] { "ReplyMB_ReplyId" });
            DropTable("dbo.ReplyMBMessageBoards");
            DropTable("dbo.ReplyMBs");
            DropTable("dbo.MessageBoards");
        }
    }
}
