using Microsoft.AspNetCore.Mvc;

namespace Nvd_NetCoreLA7.Areas.Admin.Controllers
{
    [Area("Admins")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}