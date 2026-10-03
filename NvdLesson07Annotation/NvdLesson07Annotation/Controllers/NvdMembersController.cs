using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvdLesson07Annotation.Models;

namespace NvdLesson07Annotation.Controllers
{


    public class NvdMembersController : Controller
    {

        private static List<NvdMember> nvdMembers = new List<NvdMember>();

        // GET: NvdMembersController
        public ActionResult Index()
        {
            return View(nvdMembers);
        }

        // GET: NvdMembersController/Details/5
        public ActionResult Details(int id)
        {   
            if(id <= 0)
            {
                return BadRequest("Invalid member ID.");
            }

            var member = nvdMembers.FirstOrDefault(m => m.Id == id);
            if(member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: NvdMembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvdMembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NvdMember nvdMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nvdMember);
                }
                nvdMember.Id = nvdMembers.Count == 0 ? 1 : nvdMembers.Max(m => m.Id) + 1;
                nvdMembers.Add(nvdMember);


                // TODO: Thêm logic lưu nvdMember vào CSDL ở đây (nếu có)

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(nvdMember);
            }
        }


        // GET: NvdMembersController/Edit/5
        public ActionResult Edit(int id)
        {
            var member = nvdMembers.FirstOrDefault(m => m.Id == id);
            if ((member == null))
            {
                return NotFound();

            }
            return View(member);
        }

        // POST: NvdMembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, NvdMember nvdMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nvdMember);
                }
                var member = nvdMembers.FirstOrDefault(m => m.Id == id);
                if (member == null)
                {
                    return NotFound();
                }
                member.NvdUserName = nvdMember.NvdUserName;
                member.NvdPassword = nvdMember.NvdPassword;
                member.NvdEmail = nvdMember.NvdEmail;
                member.NvdPhone = nvdMember.NvdPhone;

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View(nvdMember);
            }
        }
  
    


        // GET: NvdMembersController/Delete/5
        public ActionResult Delete(int id)
        {
            var member = nvdMembers.FirstOrDefault(m => m.Id == id);
            if(member == null) {
                return NotFound();
            }
            return View(member );
        }

        // POST: NvdMembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, IFormCollection collection)
        {
            var member = nvdMembers.FirstOrDefault(m => m.Id == id);
            if (member != null)
            {
                nvdMembers.Remove(member);
            }


            return RedirectToAction(nameof(Index));

        }
    }
}
