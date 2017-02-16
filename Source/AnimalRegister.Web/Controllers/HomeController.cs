using System.Web.Mvc;
using Abp.Auditing;

namespace AnimalRegister.Web.Controllers
{
    [DisableAuditing]
    public class HomeController : AnimalRegisterControllerBase
    {
        /// <summary>
        /// This action is responsible for initializing the SPA interface
        /// </summary>
        public ActionResult Index()
        {
            // Redirect to the Angular JS environment
            return View("~/app/main/views/layout/layout.cshtml");
        }
    }
}