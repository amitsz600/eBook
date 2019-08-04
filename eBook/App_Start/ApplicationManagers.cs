using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using eBook.Models;
using eBook.DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;

namespace eBook
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(
        IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new UserStore<User>(context.Get<SiteContext>()));
            return manager;
        }
    }

    public class ApplicationSignInManager : SignInManager<Models.User, string>
    {
        public ApplicationSignInManager(UserManager<User, string> userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleManager : RoleManager<Role, string>
    {
        public ApplicationRoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<Role>(context.Get<SiteContext>()));
        }
    }
}