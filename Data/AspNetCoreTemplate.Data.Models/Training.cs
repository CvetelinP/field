namespace FieldPlatform.Data.Models
{
    using System.Collections.Generic;

    using FieldPlatform.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    {
        public Training()
        {
            this.Reports = new HashSet<Report>();
        }

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public string TrainingPdfUrl { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
