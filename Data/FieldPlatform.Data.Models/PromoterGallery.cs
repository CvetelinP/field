namespace FieldPlatform.Data.Models
{
    using FieldPlatform.Data.Common.Models;

    public class PromoterGallery : BaseModel<int>
    {
        public int PromoterId { get; set; }

        public Promoter Promoter { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
