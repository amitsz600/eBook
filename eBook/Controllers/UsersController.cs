using Microsoft.AspNet.Identity.Owin;
using eBook.DAL;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using eBook.Models;
using System.Threading.Tasks;
using eBook.App_Start;
using System.Data.Entity;
using System;
using System.Linq;

namespace eBook.Controllers
{
    public class UsersController : Controller
    {
        #region Data Members

        private SiteContext db = new SiteContext();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private ApplicationRoleManager _roleManager;

        #endregion

        #region CTOR 

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) : this()
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        #endregion

        #region Properties

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { this._roleManager = value; }
        }

        #endregion

        #region Methods

        // /Users/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                User user = userManager.Find(login.Email, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(Url.Action("Index", "Books"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        //
        // GET: /Users/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        //POST: /Users/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Birthday = model.Birthday,
                    Address = model.Address
                };

                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign Role
                    string id = UserManager.FindByEmail(model.Email).Id;

                    IdentityResult idenResult = (model.isAdmin)
                        ? UserManager.AddToRole(id, IdentityConfigGlobals.MANAGER_ROLE)
                        : UserManager.AddToRole(id, IdentityConfigGlobals.USER_ROLE);


                    return RedirectToAction("Login", "Users");
                }
                AddErrors(result);
            }

            return View(model);
        }

        //GET: /Users/List
        [HttpGet]
        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        public ActionResult List()
        {
            return View(db.Users);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult LogOut()
        {
            SignInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Books", new { message = "Succesfully logged out" });
        }

        //GET: /Users/Update?id
        [HttpGet]
        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        public ActionResult Update(string id)
        {
            User user = db.Users.Find(id);
            user.UserRoles = db.Roles.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });
            return View(user);
        }

        //PUT: /Users/Update?id
        [HttpPost]
        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        public ActionResult Update([Bind(Include = "Id,Email,Address,BirthDay,RoleId")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var foundUser = db.Users.Find(user.Id);
                    UpdateModel<User>(foundUser);

                    var userRoles = db.Roles.Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    });

                    try
                    {
                        string roleNameNew = userRoles.ToList().Where(
                            r => r.Value == Request.Params["RoleId"]).First().Text;

                        string roleNameOld = userRoles.ToList().Where(
                            r => r.Value == foundUser.Roles.First().RoleId).First().Text;

                        // Update User Roles
                        UserManager.AddToRole(foundUser.Id, roleNameNew);
                        UserManager.RemoveFromRole(foundUser.Id, roleNameOld);
                    }
                    catch (Exception exRole)
                    {
                    }

                    this.db.Entry(foundUser).State = EntityState.Modified;
                    db.SaveChanges();
                    RedirectToAction("List");
                }
                ModelState.AddModelError("", "One of the values is not valid");

                return RedirectToAction("List", new { message = "Update successful" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }
            finally
            {
                //return RedirectToAction("List");
            }
        }

        //POST: /Users/Search/id
        [HttpGet]
        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        public ActionResult Search(string Email, DateTime? FromDate, DateTime? ToDate, string Address)
        {
            // Init dates to min and max if nulls
            if (FromDate == null)
            {
                FromDate = DateTime.MinValue;
            }

            if (ToDate == null)
            {
                ToDate = DateTime.MaxValue;
            }


            var UsersFilterQuery = from user
                    in db.Users
                                   where (user.Email.Contains(Email))
                                   where ((user.Birthday >= FromDate) && (user.Birthday <= ToDate))
                                   where (user.Address.Contains(Address))
                                   select user;

            return View("List", UsersFilterQuery);
        }


        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        public ActionResult Remove(string id)
        {
            try
            {
                User foundUser = db.Users.Find(id);
                db.Entry(foundUser).State = EntityState.Deleted;
                db.Users.Remove(foundUser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View("List", db.Users);
            }

            return Redirect("List");
        }

        #endregion


        #region Private Methods

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion
    }
}