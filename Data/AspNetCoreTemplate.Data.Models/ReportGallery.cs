namespace FieldPlatform.Data.Models
{
    using FieldPlatform.Data.Common.Models;

    public class ReportGallery : BaseModel<int>
    {
        public int ReportId { get; set; }

        public Report Report { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
