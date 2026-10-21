using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nvd_Lesson10.Models
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController () {
            // tạo danh sách sinh viên với 4 dư liệu mẫu 

            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id= 101, name = " Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true,
                    Address = "A1-2018", email = "name@g.com"

                },

                 new Student()
                {
                    Id= 102, name = " Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true,
                    Address = "A1-2018", email = "name@g.com" },
                  new Student()
                {
                    Id= 103, name = " Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true,
                    Address = "A1-2018", email = "name@g.com" },

                new Student()
                {
                    Id= 104, name = " Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true,
                    Address = "A1-2018", email = "name@g.com" },

            };




        }
        [Route("Admin/Student/List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet]
        [Route("Admin/Student/Add")]
        public IActionResult Create()
        {
            // Danh sách giới tính cho radio button
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            // Danh sách ngành cho select-option
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
