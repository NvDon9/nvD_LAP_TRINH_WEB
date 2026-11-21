using Microsoft.AspNetCore.Mvc;
using NguyenVanDong_24120707_Mau2026.Models;

namespace NguyenVanDong_24120707_Mau2026.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _context;

        public TheLoaiMenuViewComponent(QlnhaSachContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var theLoais = _context.TheLoais.ToList();
            return View(theLoais);
        }
    }
}
