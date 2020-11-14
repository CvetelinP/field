using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Data.Models
{
    public class PromoterGroup
    {
        public int Id { get; set; }
        public int PromoterId { get; set; }
        public Promoter Promoter { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
