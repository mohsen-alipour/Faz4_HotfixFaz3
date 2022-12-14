using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class ServiceCommentDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string? CommentText { get; set; }
        public string UserName { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
