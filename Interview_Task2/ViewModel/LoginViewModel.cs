using System.ComponentModel.DataAnnotations;

namespace Interview_Task2.ViewModel
{
    public class LoginViewModel
    {
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Số điện thoại không hợp lệ")]
        [RegularExpression(@"^(?=.*[0-9]).{10,}$", ErrorMessage = "Số điện thoại chỉ bao gồm ký tự số")]
        public string PhoneNumber { get; set; }

        [StringLength(320, MinimumLength = 10, ErrorMessage = "Độ dài email sai quy định")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email đã nhập không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Mật khẩu phải có ít nhất một ký tự in hoa, in thường và số")]
        public string Password { get; set; }
    }
}
