using Microsoft.AspNetCore.Mvc;
using NguyenVanDon_g241237007.Models;


namespace NguyenVanDon_g241237007.ViewCompanents


{
    public class MenuViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public MenuViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return View(loaiHangs);
        }
    }
}
