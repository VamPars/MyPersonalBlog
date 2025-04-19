using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyPersonalBlog.DataLayer.DTOS
{
    public class CreateBlogGroupViewModel
    {
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        [MinLength(5, ErrorMessage = "مقدار {0} باید حداقل 5 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "مقدار {0} باید حداکثر 20 کاراکتر باشد")]
        public string BlogGroupName { get; set; }

    }
    public class EditBlogGroupViewModel
    {
        [Required(ErrorMessage = "مقدار الزامی است")]
        public int Id { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        [MinLength(5, ErrorMessage = "مقدار {0} باید حداقل 5 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "مقدار {0} باید حداکثر 20 کاراکتر باشد")]
        public string BlogGroupName { get; set; }

    }

    public class CreateBlogViewModel
	{
        [Display(Name = "عنوان مطلب")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        [MinLength(5, ErrorMessage = "مقدار {0} باید حداقل 5 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "مقدار {0} باید حداکثر 20 کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات کوتاه مطلب")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        [MinLength(20, ErrorMessage = "مقدار {0} باید حداقل 20 کاراکتر باشد")]
        [MaxLength(50, ErrorMessage = "مقدار {0} باید حداکثر 20 کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "مطلب")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        public string Description { get; set; }
        
        [Display(Name = "پوستر")]
        public IFormFile Thumbnail { get; set; }
        
        [Display(Name = "برچسب ها")]
        public string? Tags { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "مقدار {0} الزامی است")]
        public int BlogGroupId { get; set; }
    }


}
