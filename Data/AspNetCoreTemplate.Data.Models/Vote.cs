using AspNetCoreTemplate.Data.Common.Models;
using AspNetCoreTemplate.Data.Models.Enum;

namespace AspNetCoreTemplate.Data.Models
{
    public class Vote : BaseModel<int>
    {
        public int PromoterId { get; set; }

        public Promoter Promoter { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }


        public VoteType Type { get; set; }
    }
}
