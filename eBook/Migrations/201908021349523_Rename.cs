namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Books");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Books", newName: "Products");
        }
    }
}
