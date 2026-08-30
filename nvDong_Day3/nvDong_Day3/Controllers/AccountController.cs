using Microsoft.AspNetCore.Mvc;
using nvDong_Day3.Models;

namespace nvDong_Day3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Accountcs> accounts = new List<Accountcs>
            {
                new Accountcs()
                {
                    Id = 1, Name="Nguyễn Văn Đạt",
                    Email="dat@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/02.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2004,7,10)
                },
                new Accountcs()
                {
                    Id = 2, Name="Minh Quân",
                    Email="Quan@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/03.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,7,15)
                },
                new Accountcs()
                {
                    Id = 3, Name="Văn Hùng",
                    Email="Hung@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                },
                new Accountcs()
                {
                    Id = 4, Name="Nguyễn Hằng",
                    Email="Hang@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/05.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(1984,10,24)
                },
                new Accountcs()
                {
                    Id = 5, Name="Văn Phong",
                    Email="Phong@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/06.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                },
                new Accountcs()
                {
                    Id = 6, Name="Dieu Linh",
                    Email="Linh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/07.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                }
            };

            // Truyền dữ liệu qua view bằng ViewBag
            ViewBag.Accounts = accounts;
            return View();
        }

        // Định nghĩa url và tên riêng cho route của action này
        // -> truy cập được qua /ho-so-cua-toi thay vì /Account/Profile
        [Route("ho-so-cua-toi/{id?}", Name = "profile")]
        public IActionResult Profile(int id)
        {
            // Danh sách Account y hệt bên Index (thực tế nên tách ra dùng chung)
            List<Accountcs> accounts = new List<Accountcs>
            {
                new Accountcs()
                {
                    Id = 1, Name="Nguyễn Văn Đạt",
                    Email="dat@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/02.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2004,7,10)
                },
                new Accountcs()
                {
                    Id = 2, Name="Minh Quân",
                    Email="Quan@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/03.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,7,15)
                },
                new Accountcs()
                {
                    Id = 3, Name="Văn Hùng",
                    Email="Hung@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                },
                new Accountcs()
                {
                    Id = 4, Name="Nguyễn Hằng",
                    Email="Hang@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(1984,10,24)
                },
                new Accountcs()
                {
                    Id = 5, Name="Văn Phong",
                    Email="Phong@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                },
                new Accountcs()
                {
                    Id = 6, Name="Dieu Linh",
                    Email="Linh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar= Url.Content("~/Avatar/04.jfif"),
                    Gender=1, Bio="My name is small",
                    Birthday= new DateTime(2006,10,24)
                }
            };

            
            Accountcs? account = accounts.FirstOrDefault(ac => ac.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            // Gửi đối tượng account qua view
            ViewBag.account = account;
            return View();
        }
    }
}
