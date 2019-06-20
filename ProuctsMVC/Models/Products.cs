using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProuctsMVC.Models
{
    public class Products
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا دسته بندی  را وارد نمایید.")]
        public int? CategoryId { get; set; }
        public virtual Company Company { get; set; }
        [Display(Name = "شرکت سازنده")]
        [Required(ErrorMessage = "لطفا شرکت سازنده محصول را وارد نمایید.")]
        public int? CompanyId { get; set; }

        public virtual Country Country { get; set; }
        [Display(Name = "کشورسازنده")]
        [Required(ErrorMessage = "لطفا کشورسازنده  را وارد نمایید.")]
        public int? CountryId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا برند محصول را وارد نمایید.")]
        public string BrandName { get; set; }
        [Display(Name = "مدل محصول")]
        [Required(ErrorMessage = "لطفا مدل محصول را وارد نمایید.")]
        public string ModelNo { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمایید.")]
        public string Description { get; set; }
    }
}