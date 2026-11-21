using Microsoft.AspNetCore.Mvc;
using NguyenVanDong_24120707_Mau2026.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace NguyenVanDong_24120707_Mau2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _context;

        public HomeController(QlnhaSachContext context)
        {
            _context = context;
        }
        // load sach co gia >= 100 va gia khac null
        public IActionResult Index()
        {
            var lisSach = _context.Saches
                .Where(s => s.Gia.HasValue && s.Gia.Value >= 100)
                .ToList();
            ViewBag.SectionTitle = "NGUYỄN VĂN ĐÔNG";
            return View(lisSach);
        }
        // loc sach theo the loai AJAX
        [HttpGet]
       
        public IActionResult GetBookByCategory(int maTl, string tenTl)
        {
            var books = _context.Saches.Where(s => s.MaTl == maTl).ToList();
            ViewBag.SectionTitle = tenTl.ToUpper();
            return PartialView("_SachListPartial", books);
        }

        // câu 5 hiên thij form thêm sách 
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            ViewBag.SectionTitle = "NGUYỄN VĂN ĐÔNG";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl", sach.MaTl);
            ViewBag.SectionTitle = "NGUYỄN VĂN ĐÔNG";
            return View(sach);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
