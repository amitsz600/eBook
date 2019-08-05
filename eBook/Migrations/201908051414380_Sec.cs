namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sec : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Nickname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Nickname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
