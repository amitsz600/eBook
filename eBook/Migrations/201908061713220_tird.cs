namespace eBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tird : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "Author");
            AddForeignKey("dbo.Comments", "Author", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Author", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author" });
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
