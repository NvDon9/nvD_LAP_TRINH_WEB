using Microsoft.AspNetCore.Mvc;

namespace nvD_BT_Day2.Controllers
{
    [Route("Demo")]
    [Route("DemoController")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
