using Stefanini.Application;
using Stefanini.Domain.Repository;
using Stefanini.Repository.SqlServer;
using Stefanini.Web.Models;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Stefanini.Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authenticate(UserSys userModel)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStr"].ToString();

            IUserSysRepository userRepository = new UserSysRepository(connectionString);
            var userApp = new UserApplication(userRepository);

            var userLogged = userApp.TryLogin(userModel.Email, userModel.Password);

            if (userLogged != null)
            {
                Session["userLogin"] = userLogged.Login;
                Session["userEmail"] = userLogged.Email;
                Session["userIsAdmin"] = userLogged.UserRole.IsAdmin;
                Session["userId"] = userLogged.Id;

                FormsAuthentication.SetAuthCookie(userLogged.Email, false);

                return RedirectToAction("Index", "Customer");
            }
            else
            {
                userModel.LoginErrorMessage = "“The e-mail and/or password entered is invalid. Please try again.";
                return View("Index", userModel);
            }
        }
    }
}