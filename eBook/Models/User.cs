using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBook.Models
{
    public class User : IdentityUser
    {
        private string _address;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Text)]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = (value) ?? String.Empty;
            }
        }

        [HiddenInput(DisplayValue = false)]
        public IEnumerable<SelectListItem> UserRoles { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [HiddenInput(DisplayValue = false)]
        // Likes Posts
        public virtual ICollection<Post> Posts { get; set; }
    }
}