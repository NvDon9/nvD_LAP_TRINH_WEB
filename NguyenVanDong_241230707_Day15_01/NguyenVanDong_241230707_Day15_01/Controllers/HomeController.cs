using Microsoft.AspNetCore.Mvc;
using NguyenVanDong_241230707_Day15_01.Models;
using System.Diagnostics;

namespace NguyenVanDong_241230707_Day15_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _context;

    

        public HomeController(QltaiSanContext context)
        {
            _context = context;
        }
        // lọc tài sản có nguyen gia >= 20 
        public IActionResult Index()
        {
            ViewBag.TieuDe = "Nguyen Van Dong";
                var TaiSans = _context.TaiSans.Where(ts => ts.NguyenGia >= 20).ToList();
            return View(TaiSans);
        }

        // lọc AJAX
        
        
        public IActionResult FillterbyLoai(int maLoai)
        {
            var Taisans = _context.TaiSans.Where(ts => ts.MaLoai == maLoai).ToList();

            return PartialView("_TaiSanListPartial", Taisans);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
