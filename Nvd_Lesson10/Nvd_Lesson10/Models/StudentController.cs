using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nvd_Lesson10.Models
{
    public class StudentController : Controller
    {
        private readonly List<Student> listStudents = new()
        {
            new Student { Id = 101, name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", email = "name@gmail.com", DateOfBorth = new DateTime(2000, 1, 1), Score = 8 },
            new Student { Id = 102, name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", email = "name@gmail.com", DateOfBorth = new DateTime(2000, 1, 1), Score = 8 },
            new Student { Id = 103, name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", email = "name@gmail.com", DateOfBorth = new DateTime(2000, 1, 1), Score = 8 },
            new Student { Id = 104, name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", email = "name@gmail.com", DateOfBorth = new DateTime(2000, 1, 1), Score = 8 }
        };

        [Route("Admin/Student/List")]
        public IActionResult Index() => View(listStudents);

        [HttpGet]
        [Route("Admin/Student/Add")]
        public IActionResult Create()
        {
            PopulateFormOptions();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/Student/Add")]
        public IActionResult Create(Student s)
        {
            if (!ModelState.IsValid)
            {
                PopulateFormOptions();
                return View(s);
            }

            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }

        private void PopulateFormOptions()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>
            {
                new("IT", "0"), new("BE", "1"), new("CE", "2"), new("EE", "3")
            };
        }
    }
}
