using Microsoft.AspNetCore.Mvc;
using nvD_Lesson2.Models;

namespace nvD_Lesson2.Controllers
{
    public class NvdProductController : Controller
    {
        public IActionResult Index()
        {
            // tạo 1 sản phẩm
            var product = new NvdProduct()
            {
                productId = "P001",
                productName = "ASUS",
                quantity = 100,
                price = 1200m
            };
            ViewBag.productVB = product;
            ViewData["productVD"] = product;
            return View();
        }

        public IActionResult getAllProducts()
        {
            // tạo mock data
            List<NvdProduct> products = new List<NvdProduct>
{
    new NvdProduct { productId = "P001", productName = "Laptop Asus ROG Strix", quantity = 15, price = 28500000m },
    new NvdProduct { productId = "P002", productName = "Bàn phím cơ Akko 3087", quantity = 45, price = 1250000m },
    new NvdProduct { productId = "P003", productName = "Chuột không dây Logitech MX Master 3S", quantity = 30, price = 2490000m },
    new NvdProduct { productId = "P004", productName = "Màn hình Dell UltraSharp 27 inch", quantity = 10, price = 9800000m },
    new NvdProduct { productId = "P005", productName = "Tai nghe Sony WH-1000XM5", quantity = 20, price = 7990000m },
    new NvdProduct { productId = "P006", productName = "Ổ cứng SSD Samsung 980 Pro 1TB", quantity = 50, price = 2890000m },
    new NvdProduct { productId = "P007", productName = "RAM Corsair Vengeance 16GB DDR5", quantity = 60, price = 1650000m },
    new NvdProduct { productId = "P008", productName = "Webcam Logitech C920 Pro", quantity = 25, price = 1850000m },
    new NvdProduct { productId = "P009", productName = "Gế công nghệ cao Ergonomic Kingston", quantity = 8, price = 4500000m },
    new NvdProduct { productId = "P010", productName = "Loa Bluetooth JBL Flip 6", quantity = 35, price = 2990000m }
};
            // lưu vào đối tượng Viewdata để chuyển lên view
            ViewData["products"] = products;

            return View("Products");
        }


    }
}
