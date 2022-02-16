namespace GreenThumb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bytenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MessageBoard", "ThreadPhoto", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MessageBoard", "ThreadPhoto", c => c.Byte(nullable: true));
        }
    }
}
