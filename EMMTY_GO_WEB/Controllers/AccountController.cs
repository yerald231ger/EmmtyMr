using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using EMMTY_GO_WEB.Models;
using EMMTY_GO_WEB.Object;
using WebGrease.Css.Extensions;

namespace EMMTY_GO_WEB.Controllers
{
   
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        [AllowAnonymous]
        public ActionResult PartialLogin() 
        {
            return PartialView("PartialLogin");
        }

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var dictionaryUserRoles = new Dictionary<string,string>();
            foreach (var user in UserManager.Users.ToList())
            {
                var listRole = UserManager.GetRoles(user.Id).ToList();
                string str = null;
                listRole.ForEach(l => str += (l + "-"));
                dictionaryUserRoles.Add(user.Id, str.Substring(0, str.Length - 1));
            }
            ViewBag.UserRole = dictionaryUserRoles;
            return View(UserManager.Users.Where(u => !u.Roles.Select(r => r.RoleId).Contains("Atm")).ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexAtmUser()
        {
            var dictionaryUserRoles = new Dictionary<string, string>();
            foreach (var user in UserManager.Users.ToList())
            {
                var listRole = UserManager.GetRoles(user.Id).ToList();
                string str = null;
                listRole.ForEach(l => str += (l + "-"));
                dictionaryUserRoles.Add(user.Id, str.Substring(0, str.Length - 1));
            }
            ViewBag.UserRole = dictionaryUserRoles;
            return View(UserManager.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains("Atm")).ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = UserManager.FindById(id);
            ViewBag.IsAtm = UserManager.IsInRole(id, "Atm");
            ViewBag.IsAdmin = UserManager.IsInRole(id, "Admin");
            ViewBag.Roles = RolesToDictionary();
            ViewBag.clientes = ClientesSelectList(user);
            return user == null ? (ActionResult) HttpNotFound() : View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(
            [Bind(Include = "UserName,Id,Email,Name,PhoneNumber,LastName,AlterEmail,AlterPhoneNumber")] ApplicationUser user, FormCollection roles, int? idCliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = RolesToDictionary();
                ViewBag.clientes = ClientesSelectList(user);
                return View(user);
            }

            if (!UserManager.IsInRole(user.Id, "Atm"))
            {
                using (var db = new ApplicationDbContext())
                {
                    var cliente = db.Clientes.Find(idCliente);
                    var _user = db.Users.Find(user.Id);
                    if (!_user.Cliente.Equals(cliente))
                    {
                        var cajeros = _user.Cajeros.ToList();
                        foreach (var c in cajeros)
                        {
                            _user.Cajeros.Remove(c);
                        }
                        _user.Cliente = cliente;
                        db.SaveChanges();
                    }
                }
            }

            var result = UserManager.UpdateUser(user);

            if (result.Succeeded)
            {
                foreach (var role in roles)
                {
                    var r = RoleManager.FindById(role.ToString());

                    if (r == null) continue;
                    var value = roles[role.ToString()].Split(',');
                    if (bool.Parse(value[0]))
                    {
                        UserManager.AddToRole(user.Id, r.Name);
                    }
                    else
                    {
                        UserManager.RemoveFromRole(user.Id, r.Name);
                    }
                }
                return RedirectToAction("Index");
            }
            AddErrors(result);
            ViewBag.Roles = RolesToDictionary();
            ViewBag.clientes = ClientesSelectList(user);
            return View(UserManager.FindById(user.Id));
        }

        // GET: /Cliente/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = await UserManager.FindByIdAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult EditUser()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return PartialView("EditForUser", user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditForUser([Bind(Include = "UserName,Id,Email,Name,PhoneNumber,LastName,AlterEmail,AlterPhoneNumber")] ApplicationUser user)
        {
            if (!ModelState.IsValid) return View(user);

            var result = UserManager.UpdateUser(user);

            return RedirectToAction("Manage", result.Succeeded ? new {Message = ManageMessageId.UpdatedDataSuccess} : new { Message = ManageMessageId.Error });
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.IsAtm = UserManager.IsInRole(id, "Atm");
            ViewBag.IsAdmin = UserManager.IsInRole(id, "Admin");
            return View(user);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await UserManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                await SignInAsync(user, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            ModelState.AddModelError("", "Invalid username or password.");

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> PartialLogin(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return Json(new {modelState = false}, JsonRequestBehavior.AllowGet);
            var user = await UserManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                await SignInAsync(user, model.RememberMe);
                return Json(new { modelState = true }, JsonRequestBehavior.AllowGet);
            }
            ModelState.AddModelError("", "Invalid username or password.");

            // If we got this far, something failed, redisplay form
            return Json(new { modelState = false }, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterAtmUser()
        {
            ViewBag.Cajeros = CajerosSelectList();
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAtmUser(RegisterViewModel model, int idCajero)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cajeros = CajerosSelectList();
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNomber,
                Name = model.Name,
                LastName = model.LastName
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = await UserManager.AddToRoleAsync(user.Id, "ATM");
                using (var db = new ApplicationDbContext())
                {
                    db.Cajeros.Find(idCajero).AtmUserId = user.Id;
                    db.SaveChanges();
                }
                if (!result.Succeeded)
                {
                    AddErrors(result);
                }
                else
                {
                    return RedirectToAction("IndexAtmUser");
                }
            }
            else
            {
                ViewBag.clientes = ClientesSelectList();
                ViewBag.roleId = RolesSelectList();
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.clientes = ClientesSelectList();
            ViewBag.roleId = RolesSelectList();
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string roleId, int? idCliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.clientes = ClientesSelectList();
                ViewBag.roleId = RolesSelectList();
                return View(model);
            }
            
            var user = new ApplicationUser
            {
                UserName = model.Email, 
                Email = model.Email, 
                PhoneNumber = model.PhoneNomber,
                Name = model.Name,
                LastName = model.LastName,
                AlterEmail = model.AlterEmail,
                AlterPhoneNumber = model.AlterPhoneNomber
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = await UserManager.AddToRoleAsync(user.Id, roleId);

                if (roleId != "Atm" && (idCliente != null))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var cliente = db.Clientes.Find(idCliente);
                        db.Users.Find(user.Id).Cliente = cliente;
                        db.SaveChanges();
                    }
                }

                if (!result.Succeeded)
                {
                    AddErrors(result);
                }
                else if(!UserManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index");
                }
                else if (UserManager.IsInRole(user.Id, "Admin"))
                {
                     var _user = UserManager.Find(user.UserName, model.Password);
                     await SignInAsync(_user, false);
                     return RedirectToAction("Index","Home");
                }
            }
            else
            {
                ViewBag.clientes = ClientesSelectList();
                ViewBag.roleId = RolesSelectList();
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            ManageMessageId? message = result.Succeeded ? ManageMessageId.RemoveLoginSuccess : ManageMessageId.Error;
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "Ha ocurrido un error al intentar actualizar la informacion."
                : message == ManageMessageId.UpdatedDataSuccess ? "Tu informacion ha sido cambiada Satisfactoriamente."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            var hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (!ModelState.IsValid) return View(model);
                var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                AddErrors(result);
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                var state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (!ModelState.IsValid) return View(model);
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.FindAsync(loginInfo.Login);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage");
            }
            return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null) UserManager.Dispose();
                UserManager = null;
                if (RoleManager != null) RoleManager.Dispose();
                RoleManager = null;
            }
            base.Dispose(disposing);
        }

        #region AddAtmUser
        
        [Authorize(Roles = "Admin")]
        public ActionResult ListCajerosUser(string id)
        {
            var user = UserManager.FindById(id);

            var cajeros = user.Cliente.Cajeros;

            var a = new Dictionary<Cajero,bool>();
            var b = new Dictionary<Cajero,bool>();
            var c = new Dictionary<Cajero,bool>();

            var puntero = 0;

            foreach (var item in cajeros)
            {
                switch (puntero)
                {
                    case 0:
                        a.Add(item, user.Cajeros.Contains(item));
                        puntero++;
                        break;
                    case 1:
                        b.Add(item, user.Cajeros.Contains(item));
                        puntero++;
                        break;
                    case 2:
                        c.Add(item, user.Cajeros.Contains(item));
                        puntero = 0;
                        break;
                }
            }

            ViewBag.TblCajerosA = a;
            ViewBag.TblCajerosB = b;
            ViewBag.TblCajerosC = c;
            
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrRemoveCajerosUser(string id, FormCollection formCollection)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.First(u => u.Id == id);
                var dictionary = new Dictionary<string, bool>();

                foreach (var key in formCollection)
                {
                    if (!key.ToString().Contains("NS:")) continue;
                    var ns = key.ToString();
                    dictionary.Add(ns.Substring(ns.LastIndexOf(':') + 1).Trim(),
                        bool.Parse(formCollection[key.ToString()].Split(',')[0]));
                }
               
                foreach (var nsc in dictionary)
                {
                    switch (nsc.Value)
                    {
                        case true:
                            user.Cajeros.Add(user.Cliente.Cajeros.First(c => c.NSCajero == nsc.Key));
                            break;
                        default:
                            user.Cajeros.Remove(user.Cliente.Cajeros.First(c => c.NSCajero == nsc.Key));
                            break;
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            UpdatedDataSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        
        private List<SelectListItem> ClientesSelectList()
        {
            List<SelectListItem> idCliente;
            using (var db = new ApplicationDbContext())
            {
                idCliente = db.Clientes.Select(c => new SelectListItem { Value = c.IdCliente.ToString(), Text = c.NombreCliente }).ToList();
            }
            ViewBag.clientes = idCliente;
            return idCliente;
        }

        private List<SelectListItem> ClientesSelectList(ApplicationUser user)
        {
            List<SelectListItem> list;
            if(user.Cliente == null)
                return new List<SelectListItem> { new SelectListItem { Text = "Null"} };
            using (var db = new ApplicationDbContext())
            {
                list = db.Clientes.Select(c => new SelectListItem { Value = c.IdCliente.ToString(), Text = c.NombreCliente, Selected = (user.Cliente.IdCliente == c.IdCliente) }).ToList();
            }
            ViewBag.clientes = list;
            return list;
        }

        private List<SelectListItem> RolesSelectList()
        {
            return RoleManager.Roles.OrderBy(r => r.Name).ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
        }

        private List<SelectListItem> CajerosSelectList()
        {
            List<SelectListItem> list;
            using (var db = new ApplicationDbContext())
            {
                list = db.Cajeros.Where(c =>  c.AtmUserId == null).Select(cc => new SelectListItem { Value = cc.IdCajero.ToString(), Text = cc.NSCajero, }).ToList();
            }
            return list;
        }

        private Dictionary<string,string> RolesToDictionary()
        {
            var roles = new Dictionary<string, string>();
            RoleManager.Roles.ForEach(r => roles.Add(r.Id, r.Name));
            return roles;
        }

        #endregion

        #region AuthenticationConsole

        [AllowAnonymous]
        public JsonResult ImOnLine()
        {
            return Json("EmmtyGO", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ConsoleAuth(string email, string password)
        {
            var user = await UserManager.FindAsync(email, password);
            if (user != null)
            {
                await SignInAsync(user, false);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public JsonResult StartSqlDependency()
        {
            if (Startup.SqlStarted)
                return Json("The Sql Has been Already Started", JsonRequestBehavior.AllowGet);
            try
            {
                SqlDependency.Start(ConfigurationManager.ConnectionStrings["EmmtyGoDbDefaultConnection"].ConnectionString);
                Startup.SqlStarted = true;
                return Json("The SqlDependency Has Started", JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult StopSqlDependency()
        {
            if (!Startup.SqlStarted)
                return Json("The Sql Has been Already Stoped", JsonRequestBehavior.AllowGet);
            try
            {
                SqlDependency.Stop(ConfigurationManager.ConnectionStrings["EmmtyGoDbDefaultConnection"].ConnectionString);
                Startup.SqlStarted = false;
                return Json("The SqlDependency Has Stoped",JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }


}