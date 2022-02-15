namespace GreenThumb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GardenTable",
                c => new
                    {
                        GardenId = c.Int(nullable: false, identity: true),
                        GardenName = c.String(nullable: false, maxLength: 100),
                        PlantType = c.Int(nullable: false),
                        PlantCount = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.GardenId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        UserPhoto = c.Byte(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.MessageBoard",
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
                "dbo.ReplyMB",
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
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ProfileGardenTable",
                c => new
                    {
                        Profile_ProfileId = c.Int(nullable: false),
                        GardenTable_GardenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ProfileId, t.GardenTable_GardenId })
                .ForeignKey("dbo.Profile", t => t.Profile_ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.GardenTable", t => t.GardenTable_GardenId, cascadeDelete: true)
                .Index(t => t.Profile_ProfileId)
                .Index(t => t.GardenTable_GardenId);
            
            CreateTable(
                "dbo.MessageBoardProfile",
                c => new
                    {
                        MessageBoard_ThreadId = c.Guid(nullable: false),
                        Profile_ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageBoard_ThreadId, t.Profile_ProfileId })
                .ForeignKey("dbo.MessageBoard", t => t.MessageBoard_ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.Profile_ProfileId, cascadeDelete: true)
                .Index(t => t.MessageBoard_ThreadId)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.ReplyMBMessageBoard",
                c => new
                    {
                        ReplyMB_ReplyId = c.Int(nullable: false),
                        MessageBoard_ThreadId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReplyMB_ReplyId, t.MessageBoard_ThreadId })
                .ForeignKey("dbo.ReplyMB", t => t.ReplyMB_ReplyId, cascadeDelete: true)
                .ForeignKey("dbo.MessageBoard", t => t.MessageBoard_ThreadId, cascadeDelete: true)
                .Index(t => t.ReplyMB_ReplyId)
                .Index(t => t.MessageBoard_ThreadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ReplyMBMessageBoard", "MessageBoard_ThreadId", "dbo.MessageBoard");
            DropForeignKey("dbo.ReplyMBMessageBoard", "ReplyMB_ReplyId", "dbo.ReplyMB");
            DropForeignKey("dbo.MessageBoardProfile", "Profile_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.MessageBoardProfile", "MessageBoard_ThreadId", "dbo.MessageBoard");
            DropForeignKey("dbo.ProfileGardenTable", "GardenTable_GardenId", "dbo.GardenTable");
            DropForeignKey("dbo.ProfileGardenTable", "Profile_ProfileId", "dbo.Profile");
            DropIndex("dbo.ReplyMBMessageBoard", new[] { "MessageBoard_ThreadId" });
            DropIndex("dbo.ReplyMBMessageBoard", new[] { "ReplyMB_ReplyId" });
            DropIndex("dbo.MessageBoardProfile", new[] { "Profile_ProfileId" });
            DropIndex("dbo.MessageBoardProfile", new[] { "MessageBoard_ThreadId" });
            DropIndex("dbo.ProfileGardenTable", new[] { "GardenTable_GardenId" });
            DropIndex("dbo.ProfileGardenTable", new[] { "Profile_ProfileId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.ReplyMBMessageBoard");
            DropTable("dbo.MessageBoardProfile");
            DropTable("dbo.ProfileGardenTable");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ReplyMB");
            DropTable("dbo.MessageBoard");
            DropTable("dbo.Profile");
            DropTable("dbo.GardenTable");
        }
    }
}
