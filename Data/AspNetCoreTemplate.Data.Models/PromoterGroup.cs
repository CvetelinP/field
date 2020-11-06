using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreTemplate.Data.Models
{
    public class PromoterGroup
    {
        [Required]
        public int PromoterId { get; set; }

     
        public Promoter Promoter { get; set; }

        public int GroupId { get; set; }

    
        public Group Group { get; set; }
    }
}
