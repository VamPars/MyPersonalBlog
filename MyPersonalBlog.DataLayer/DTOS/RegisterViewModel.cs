using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.DataLayer.DTOS
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="مقدار{0} را وارد کن")]
        [DisplayName("نام کاربری")]
        [MaxLength(15)]
        [MinLength(5)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "مقدار{0} را وارد کن")]
        [DisplayName("رمز عبور")]
        [MinLength(8)]
        public string Password { get; set; }


        [Required(ErrorMessage = "مقدار{0} را وارد کن")]
        [DisplayName("تکرار رمز عبور")]
        [MinLength(8)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "مقدار{0} را وارد کن")]
        [DisplayName("ایمیل")]
        [EmailAddress(ErrorMessage ="آدرس ایمیل صحیح نیست")]
        public string Email { get; set; }
    }
}
