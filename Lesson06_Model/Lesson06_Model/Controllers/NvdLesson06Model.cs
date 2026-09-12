using Lesson06_Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
namespace Lesson06_Model.Controllers
{
    public class NvdLesson06Model : Controller
    {

        public static readonly List<NvdMember> nvdMembers = new List<NvdMember>()
{
    new NvdMember{ NVD_MemberID = Guid.NewGuid().ToString(), NVD_UserName = "member1", NVD_FullName = "Thành viên 1", NVD_Password = "123456", NVD_Email = "tv1@gmail.com" },
    new NvdMember{ NVD_MemberID = Guid.NewGuid().ToString(), NVD_UserName = "member2", NVD_FullName = "Thành viên 2", NVD_Password = "123456", NVD_Email = "tv2@gmail.com" },
    new NvdMember{ NVD_MemberID = Guid.NewGuid().ToString(), NVD_UserName = "member3", NVD_FullName = "Thành viên 3", NVD_Password = "123456", NVD_Email = "tv3@gmail.com" },
};

        public IActionResult NVD_GetMembers()
        {
            return View(nvdMembers);  // truyền cả List ra View
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NVD_GetDetails()
        {
            var nvdMember = new NvdMember
            {
                NVD_MemberID = Guid.NewGuid().ToString(),
                NVD_UserName = "VanDong",
                NVD_Password = "111",
                NVD_FullName = "Nguyễn văn Đông",
                NVD_Email = "vandong2006bg@gmail.com"
            }
            ;
            return View(nvdMember);
        }
        // GET - hiển thị form trống
        public IActionResult NVD_Create()
        {
            return View();
        }

        // POST - nhận dữ liệu từ form khi bấm Lưu
        [HttpPost]
        public IActionResult NVD_Create(NvdMember nvdMember)
        {
            nvdMember.NVD_MemberID = Guid.NewGuid().ToString();
            nvdMembers.Add(nvdMember);
            return RedirectToAction("NVD_GetMembers");
        }

        // GET - hiển thị form với dữ liệu hiện tại theo MemberID
        public IActionResult NVD_Edit(string id)
        {
            var nvdMember = nvdMembers.FirstOrDefault(m => m.NVD_MemberID == id);
            if (nvdMember == null)
            {
                return NotFound();
            }
            return View(nvdMember);
        }

        // POST - nhận dữ liệu đã sửa, cập nhật lại vào list
        [HttpPost]
        public IActionResult NVD_Edit(NvdMember nvdMember)
        {
            var existing = nvdMembers.FirstOrDefault(m => m.NVD_MemberID == nvdMember.NVD_MemberID);
            if (existing != null)
            {
                existing.NVD_UserName = nvdMember.NVD_UserName;
                existing.NVD_FullName = nvdMember.NVD_FullName;
                existing.NVD_Password = nvdMember.NVD_Password;
                existing.NVD_Email = nvdMember.NVD_Email;
            }
            return RedirectToAction("NVD_GetMembers");
        }

        // GET - hiển thị trang xác nhận trước khi xóa
        public IActionResult NVD_Delete(string id)
        {
            var nvdMember = nvdMembers.FirstOrDefault(m => m.NVD_MemberID == id);
            if (nvdMember == null)
            {
                return NotFound();
            }
            return View(nvdMember);
        }

        // POST - thực hiện xóa sau khi xác nhận
        [HttpPost, ActionName("NVD_Delete")]
        public IActionResult NVD_DeleteConfirmed(string NVD_MemberID)
        {
            var nvdMember = nvdMembers.FirstOrDefault(m => m.NVD_MemberID == NVD_MemberID);
            if (nvdMember != null)
            {
                nvdMembers.Remove(nvdMember);
            }
            return RedirectToAction("NVD_GetMembers");
        }
    }
}

    

