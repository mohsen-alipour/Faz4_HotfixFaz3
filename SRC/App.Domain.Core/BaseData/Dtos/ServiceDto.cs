using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }
        public string CategoryTitle { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public int Price { get; set;}
     
    }
}
