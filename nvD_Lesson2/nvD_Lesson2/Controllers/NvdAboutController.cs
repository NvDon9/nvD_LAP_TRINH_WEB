using Microsoft.AspNetCore.Mvc;

namespace nvD_Lesson2.Controllers
{

    public class NvdAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Nguyễn Văn Đông";
            ViewData["class"] = "K65CNTT2_LTW";
            TempData["module"]= "ASP.NET Core MVC"; 
            return View();
        }
    }
}
