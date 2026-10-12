using System.ComponentModel.DataAnnotations;

namespace Lesson06_Model.Models
{
    public class NvdMember
    {
        public string NVD_MemberID { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string NVD_UserName { get; set; }

        [Display(Name = "Họ và tên")]
        public string NVD_FullName { get; set; }

        [Display(Name = "Mật khẩu")]
        public string NVD_Password { get; set; }

        [Display(Name = "Email")]
        public string NVD_Email { get; set; }

    }
}
