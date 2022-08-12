using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertFavoriteCategoryDto
    {
        public int ExpertCategorySpecialyId { get; set; }
        public int ExpertUserId { get; set; }
        public string CategoryTitle { get; set; }
        public int Categoryid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
