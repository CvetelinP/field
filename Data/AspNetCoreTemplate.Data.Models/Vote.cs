namespace FieldPlatform.Data.Models
{
    using FieldPlatform.Data.Common.Models;
    using FieldPlatform.Data.Models.Enum;

    public class Vote : BaseModel<int>
    {
        public int PromoterId { get; set; }

        public Promoter Promoter { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
