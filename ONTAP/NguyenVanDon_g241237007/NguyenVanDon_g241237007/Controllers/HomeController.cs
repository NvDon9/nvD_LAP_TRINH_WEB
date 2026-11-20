using Microsoft.AspNetCore.Mvc;
using NguyenVanDon_g241237007.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace NguyenVanDon_g241237007.Controllers
{
    public class HomeController : Controller
    {

        private readonly QlhangHoaContext _context;
        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        // Hien thi hang hoa gia >= 100

        public IActionResult Index()
        {
            var hangHoas = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(hangHoas);
        }

        // Loc hang hoa theo loai bang AJAX

        public IActionResult FilterByLoai(int loaihang)
        {
            var hangHoas = _context.HangHoas.Where(h => h.MaLoai == loaihang && h.Gia >= 100).ToList();
            return PartialView("_ProductList", hangHoas);
        }

        // hien thi from them moi

     
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        // 2. Hàm lưu dữ liệu
        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
