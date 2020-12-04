namespace FieldPlatform.Data.Models
{
    using System.Collections.Generic;

    using FieldPlatform.Data.Common.Models;

    public class Report : BaseDeletableModel<int>
    {
        public Report()
        {
            this.ReportGalleries = new HashSet<ReportGallery>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int? TrainingId { get; set; }

        public Training Training { get; set; }

        public string ReportUrl { get; set; }

        public ICollection<ReportGallery> ReportGalleries { get; set; }
    }
}
