namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "date");
        }
    }
}
