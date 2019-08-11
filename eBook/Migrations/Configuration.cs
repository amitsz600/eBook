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
                    Video = @"https://www.youtube.com/watch?v=JTBFnWlurqU"
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
                    Video = @"https://www.youtube.com/watch?v=tYOCTfok5Lg"
                },
                new Models.Book()
                {
                    ProductId = 3,
                    Title = "how bibi make israel empire",
                    Author = "akiva bigman",
                    Description = "bibi make israel empire",
                    genre = "Politics",
                    Price = 52,
                    publisher = "Balfur",
                    Image = "https://cdn.shopify.com/s/files/1/2776/1306/files/b4570895aece3f9e977e21ebbd1ea220_large.jpeg?v=1564913501",
                    Video = @"https://www.youtube.com/watch?v=H0Mp_BMVSTE"
                    
                },
                new Models.Book()
                {
                    ProductId = 5,
                    Title = "Be free jewish",
                    Author = "Moshe feiglin",
                    Description = "israel - guide",
                    genre = "Politics",
                    Price = 25,
                    publisher = "keter",
                    Image = "https://cdn.shopify.com/s/files/1/2776/1306/products/3721fa825accb121168287d73c7a81f0_1024x1024.PNG?v=1550060324",
                    Video = @"https://www.youtube.com/watch?v=9rcSM9J0xS0"
                },
                new Models.Book()
                {
                    ProductId = 4,
                    Title = "Tehilim",
                    Author = "King David",
                    Description = "bible book for prays",
                    genre = "Religion",
                    Price = 43,
                    publisher = "koren foundation",
                    Image = "https://d3m9l0v76dty0.cloudfront.net/system/photos/947184/large/deedb3f0ec738f637da08c0622d5595d.jpg",
                    Video = @"https://www.youtube.com/watch?v=wexLc0wfgbU",
                }
                ,
                new Models.Book()
                {
                    ProductId = 6,
                    Title = "Golda - biography",
                    Author = "yosi goldshtein",
                    Description = "bio of prime minister",
                    genre = "politics",
                    Price = 28,
                    publisher = "yediot",
                    Image = "data:image/jpeg;base64,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",
                    Video = @"https://www.youtube.com/watch?v=A0Ys8Yp_nB4"
                },
                new Models.Book()
                {
                    ProductId = 7,
                    Title = "The magician",
                    Author = "eyal berkovich",
                    Description = "eyal berko story",
                    genre = "sport",
                    Price = 49,
                    publisher = "loni choen",
                    Image = "https://s3-eu-west-1.amazonaws.com/simania-public-assets/bookimages/covers1/16684.jpg",
                    Video = @"https://www.youtube.com/watch?v=H5BR0MtQbZ4"
                },
                new Models.Book()
                {
                    ProductId = 8,
                    Title = "Dunk in face",
                    Author = "eran sela",
                    Description = "famous players who got dunk in their face",
                    genre = "sport",
                    Price = 78,
                    publisher = "modan",
                    Image = "https://s3-eu-west-1.amazonaws.com/simania-public-assets/bookimages/covers6/60451.jpg",
                    Video = @"https://www.youtube.com/watch?v=oSmE8IwesLY&t=121s",
                },
                new Models.Book()
                {
                    ProductId = 9,
                    Title = "The club",
                    Author = "ohad gringwald",
                    Description = "the secret of maccabi tel aviv club",
                    genre = "sport",
                    Price = 39,
                    publisher = "kineret",
                    Image = "data:image/jpeg;base64,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",
                    Video = @"https://www.youtube.com/watch?v=QCK3O8_BGG8"
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

            if (!context.Users.Any(u => u.UserName == "member2"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "member2@me.com", UserName = "member2", Birthday = new DateTime(1995,2,3), Address = "Givatiim" };

                context.Users.Add(user);
                manager.Create(user, "12341234");
                manager.AddToRole(user.Id, IdentityConfigGlobals.USER_ROLE);
            }

            if (!context.Users.Any(u => u.UserName == "member3"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "member3@me.com", UserName = "member3", Birthday = new DateTime(1998, 2, 3), Address = "Ashdod" };

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
                },
                new Comment()
                {
                    CommentId = 2,
                    Author = "member",
                    Body = "Good!",
                    ProductId = 2,
                    Rating = 3,
                    Title = "I Really Liked It",
                    date = new DateTime(2018, 5, 1)
                },
                new Comment()
                {
                    CommentId = 3,
                    Author = "member",
                    Body = "nice book!",
                    ProductId = 3,
                    Rating = 5,
                    Title = "I Really Liked It",
                    date = new DateTime(2017, 1, 1)
                },
                new Comment()
                {
                    CommentId = 4,
                    Author = "member",
                    Body = "great!",
                    ProductId = 4,
                    Rating = 5,
                    Title = "book",
                    date = new DateTime(2017, 1, 1)
                },
                new Comment()
                {
                    CommentId = 6,
                    Author = "member",
                    Body = "Good book!",
                    ProductId = 6,
                    Rating = 5,
                    Title = "I Liked It",
                    date = new DateTime(2019, 1, 1)
                },
                new Comment()
                {
                    CommentId = 7,
                    Author = "member",
                    Body = "bad book!",
                    ProductId = 7,
                    Rating = 1,
                    Title = "I Really Liked It",
                    date = new DateTime(2017, 1, 1)
                },
                new Comment()
                {
                    CommentId = 8,
                    Author = "member",
                    Body = "Good",
                    ProductId = 8,
                    Rating = 5,
                    Title = "nice one",
                    date = new DateTime(2018,6, 6)
                },
                new Comment()
                {
                    CommentId = 9,
                    Author = "member",
                    Body = "Good!",
                    ProductId = 9,
                    Rating = 3,
                    Title = "I Really Liked It",
                    date = new DateTime(2017, 1, 7)
                },
                new Comment()
                {
                    CommentId = 5,
                    Author = "member",
                    Body = "i really liked it!",
                    ProductId = 5,
                    Rating = 3,
                    Title = "regular",
                    date = new DateTime(2017, 5, 7)
                }


            );
        }
    }
}

