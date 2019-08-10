namespace eBook.Migrations
{
    using eBook.App_Start;
    using eBook.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eBook.DAL.SiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eBook.DAL.SiteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Books.AddOrUpdate(
                p => p.ProductId,
                new Models.Book()
                {
                    ProductId = 1,
                    Title = "the bible",
                    Author = "god",
                    Description="the book given from god to israel people",
                    genre="Religion",
                    Price=200,
                    publisher="tora",
                    Image = "https://d3m9l0v76dty0.cloudfront.net/system/photos/521767/large/df63ff97af102350e8fe9a1e03fb10b4.jpg",
                    Video = @"https://www.youtube.com/watch?v=JTBFnWlurqU",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 2,
                    Title = "Talmud",
                    Author = "rabbai shtinzlatz",
                    Description = "talmud bavli",
                    genre = "Religion",
                    Price = 200,
                    publisher = "tora",
                    Image = "https://www.korenpub.com/media/catalog/product/cache/7/image/335x335/9df78eab33525d08d6e5fb8d27136e95/t/a/talmudbavliset_2_3_1.jpg",
                    Video = @"https://www.youtube.com/watch?v=tYOCTfok5Lg",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 3,
                    Title = "how bibi make israel empire",
                    Author = "akiva bigman",
                    Description = "bibi make israel empire",
                    genre = "politics",
                    Price = 200,
                    publisher = "Balfur",
                    Image = "https://cdn.shopify.com/s/files/1/2776/1306/files/b4570895aece3f9e977e21ebbd1ea220_large.jpeg?v=1564913501",
                    Video = @"https://www.youtube.com/watch?v=H0Mp_BMVSTE",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                }
               );

            



            context.Roles.AddOrUpdate(

                    r => r.Id,

                    new Role() { Id = "1", Name = IdentityConfigGlobals.MANAGER_ROLE },

                    new Role() { Id = "2", Name = IdentityConfigGlobals.USER_ROLE }

                );

            if (!context.Users.Any(u => u.UserName == "founder2"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "founder2@me.com", UserName = "founder2", Birthday = DateTime.Today, Address = "Tel Aviv" };

                try
                {
                    IdentityResult result = manager.Create(user, "12341234");
                }
                catch (Exception ex)
                {

                    throw;
                }

                manager.AddToRole(user.Id, IdentityConfigGlobals.MANAGER_ROLE);
            }

            if (!context.Users.Any(u => u.UserName == "member"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "member@me.com", UserName = "member", Birthday = DateTime.Today, Address = "Tel Aviv" };

                context.Users.Add(user);
                manager.Create(user, "12341234");
                manager.AddToRole(user.Id, IdentityConfigGlobals.USER_ROLE);
            }

            context.Comments.AddOrUpdate(
                c => c.CommentId,
                new Comment()
                {
                    CommentId = 1,
                    Author = "member",
                    Body = "Good One!",
                    ProductId = 1,
                    Rating = 5,
                    Title = "I Really Liked It",
                    date = new DateTime(2017,1,1)
                }
            );
        }
    }
}

