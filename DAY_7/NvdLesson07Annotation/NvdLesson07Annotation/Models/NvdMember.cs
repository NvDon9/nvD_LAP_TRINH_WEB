using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NvdLesson07Annotation.Models
{
    public class NvdMember
    {
        public int Id { get; set; }

        [DisplayName("Tài Khoản")]

        [Required(ErrorMessage = "Tài Khoản không được để trống")]

        [StringLength(20, MinimumLength = 3, ErrorMessage ="Tài Khoản có độ dài trong khoảng 3-20 kí tự")]



        public string NvdUserName { get; set; }

        [DisplayName("Mật Khẩu")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu có độ dài trong khoảng 8-100 kí tự")]
        public string NvdPassword { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [DataType(DataType.EmailAddress)]
        public string NvdEmail { get; set; }

        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Số Điện Thoại không được để trống")]
        [RegularExpression(@"^0\d{9,9}", ErrorMessage = "Số Điện Thoại phải có 10 chữ số,Bắt đầu bằng số 0")]

        public string NvdPhone { get; set; }



    }
}
