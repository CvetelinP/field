namespace AspNetCoreTemplate.Data.Models
{
    using AspNetCoreTemplate.Data.Common.Models;
    using AspNetCoreTemplate.Data.Models.Enum;

    public class Vote : BaseModel<int>
    {
        public int PromoterId { get; set; }

        public Promoter Promoter { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
