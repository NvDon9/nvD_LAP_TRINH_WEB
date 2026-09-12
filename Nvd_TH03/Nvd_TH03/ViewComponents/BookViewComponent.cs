using Microsoft.AspNetCore.Mvc;
using Nvd_TH03.Models;

namespace Nvd_TH03.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
