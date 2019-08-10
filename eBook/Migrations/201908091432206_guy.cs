namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "date");
            DropColumn("dbo.Comments", "Rating");
        }
    }
}
