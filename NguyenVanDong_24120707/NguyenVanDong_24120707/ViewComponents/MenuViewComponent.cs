using Microsoft.AspNetCore.Mvc;
using NguyenVanDong_24120707.Models;

namespace NguyenVanDong_24120707.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public MenuViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return View(loaiHangs);
        }
    
    }
}
