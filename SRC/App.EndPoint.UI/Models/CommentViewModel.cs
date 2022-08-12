using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.UI.Models
{
    public class CommentViewModel
    {
        [Display(Name = "شناسه سفارش")]
        public int OrderId { get; set; }
        [Display(Name = "عنوان سرویس")]
        public string ServiceTitle { get; set; }
        [Display(Name = "نظرات")]
        public string CommentTitle { get; set; }

        [Display(Name = "شناسه نظر دهنده")]
        public int CustomerUserId { get; set; }
        public int ServiceId { get; set; }

    }
}
