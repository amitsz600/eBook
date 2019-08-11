namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ne2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "TwitterWidgets");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "TwitterWidgets", c => c.String(maxLength: 1000));
        }
    }
}
