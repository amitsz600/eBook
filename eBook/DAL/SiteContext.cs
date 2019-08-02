using eBook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eBook.DAL
{
    public class SiteContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Book> Products { get; set; }

        public static SiteContext Create()
        {
            return new SiteContext();
        }
    }
}