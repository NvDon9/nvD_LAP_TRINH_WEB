using Microsoft.AspNetCore.Mvc;
using NguyenVanDong_241230707_Day15_01.Models;
namespace NguyenVanDong_241230707_Day15_01.Components
{
    public class LoaitaiSanViewComponent: ViewComponent
    {
        private readonly QltaiSanContext _context;
        public LoaitaiSanViewComponent(QltaiSanContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var loaiTaiSans = _context.LoaiTaiSans.ToList();
            return View(loaiTaiSans);
        }
    }
}
