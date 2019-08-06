namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Author", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author" });
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "Author");
            AddForeignKey("dbo.Comments", "Author", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
