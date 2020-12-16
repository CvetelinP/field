namespace FieldPlatformWeb.ViewModels.Report
{
    using System.Collections.Generic;

    using FieldPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class ReportViewModel : IMapFrom<FieldPlatform.Data.Models.Report>
    {
        public int Id { get; set; }

        public int? TrainingId { get; set; }

        public IFormFile ReportFile { get; set; }

        public string ReportUrl { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public IFormFileCollection GalleryFiles { get; set; }

        public IList<GalleryReportViewModel> Gallery { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TrainingItems { get; set; }
    }
}
