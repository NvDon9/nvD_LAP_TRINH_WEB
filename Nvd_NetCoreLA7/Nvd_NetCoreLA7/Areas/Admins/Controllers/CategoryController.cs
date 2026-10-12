using Microsoft.AspNetCore.Mvc;

namespace Nvd_NetCoreLA7.Areas.Admins.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admins")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
