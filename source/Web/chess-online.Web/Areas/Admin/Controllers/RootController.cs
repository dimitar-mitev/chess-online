
namespace chess_online.Web.Areas.Admin.Controllers
{

    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Security;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;

    using chess_online.Models;
    using Data;

    using Models;
    using System.Collections.Generic;
    using System.Linq;

    [Authorize(Roles = "RootAdmin")]
    public class RootController : Controller
    {
        private ApplicationUserManager _userManager;


        public RootController()
        {

        }

        public RootController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            List<ApplicationUser> admins = new List<ApplicationUser>();
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userIds = RoleManager.FindByName("Admin").Users.Select(a => a.UserId).ToList();
            foreach (var id in userIds)
            {
                admins.Add(UserManager.FindById(id));
            }
            var model = new IndexViewModel();
            model.Admins = admins;
            return View(model);
        }

        public ActionResult Remove(string Id)
        {
            UserManager.RemoveFromRole(Id, "Admin");
            UserManager.Delete(UserManager.FindById(Id));
            return RedirectToAction("Index");
        }

        // GET: Admin/Root/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}