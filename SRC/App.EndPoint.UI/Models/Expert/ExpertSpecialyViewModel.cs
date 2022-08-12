using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.UI.Models.Expert
{
    public class ExpertSpecialyViewModel
    {
        [Display(Name = "شناسه تخصص کارشناس")]
        public int ExpertFavoriteCategoryid { get; set; }

        [Display(Name = "شناسه خدمات")]
        public int categuryid { get; set; }
        [Display(Name = "دسته بندی خدمات")]
        public string CategoryTitle { get; set; }
        //[Display(Name = "شناسه متخصص")]
        //public string ExpertUserName { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime RegisterDate { get; set; }
    }
}
