using Microsoft.AspNetCore.Mvc;

namespace WebApp01.Controllers
{
    public class MyNewController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "Văn Đông";
            ViewBag.Age = 30;
            TempData["Email"] = "dong@gmail.com";
          
            return RedirectToAction("Sample");
        }

        public IActionResult Sample()
        {
            TempData.Keep();
            return RedirectToAction("Index", "Other");
        }
    }
}
