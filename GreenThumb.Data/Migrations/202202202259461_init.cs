namespace GreenThumb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GardenTable",
                c => new
                    {
                        GardenId = c.Int(nullable: false, identity: true),
                        OwnerGUID = c.Guid(nullable: false),
                        GardenName = c.String(nullable: false, maxLength: 100),
                        PlantType = c.Int(nullable: false),
                        PlantPhoto = c.Binary(),
                        PlantCount = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.GardenId)
                .ForeignKey("dbo.Profile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        OwnerGUID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        UserPhoto = c.Binary(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.MessageBoard",
                c => new
                    {
                        ThreadId = c.Int(nullable: false, identity: true),
                        OwnerGUID = c.Guid(nullable: false),
                        ThreadContent = c.String(nullable: false),
                        ThreadTitle = c.String(nullable: false),
                        ThreadPhoto = c.Binary(),
                        ReactionType = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ThreadId)
                .ForeignKey("dbo.Profile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReplyMB",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        OwnerGUID = c.Guid(nullable: false),
                        Reply = c.String(nullable: false, maxLength: 500),
                        ReplyPhoto = c.Binary(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ThreadId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.MessageBoard", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ThreadId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        OwnerGUID = c.Guid(nullable: false),
                        ImageData = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.GardenTable", "UserId", "dbo.Profile");
            DropForeignKey("dbo.ReplyMB", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.ReplyMB", "ThreadId", "dbo.MessageBoard");
            DropForeignKey("dbo.MessageBoard", "UserId", "dbo.Profile");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ReplyMB", new[] { "ProfileId" });
            DropIndex("dbo.ReplyMB", new[] { "ThreadId" });
            DropIndex("dbo.MessageBoard", new[] { "UserId" });
            DropIndex("dbo.GardenTable", new[] { "UserId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Images");
            DropTable("dbo.ReplyMB");
            DropTable("dbo.MessageBoard");
            DropTable("dbo.Profile");
            DropTable("dbo.GardenTable");
        }
    }
}
