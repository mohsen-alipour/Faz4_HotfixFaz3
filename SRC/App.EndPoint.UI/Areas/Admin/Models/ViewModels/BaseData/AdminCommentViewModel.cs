using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.UI.Areas.Admin.Models.ViewModels.BaseData
{
    public class AdminCommentViewModel
    {
        [Display(Name = "شناسه نظرات")]
        public int Id { get; set; }

        [Display(Name = "عنوان سرویس")]
        public string ServiceTitle { get; set; }
      
        [Display(Name = "نظرات")]
        public string CommentText { get; set; }

        [Display(Name = "شناسه کاربر")]
        public string UserName { get; set; }
        [Display(Name = "تاریخ درج")]
        public DateTime CreateAt { get; set; }
      
    }
}
