namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    {
       

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public string TrainingPdfUrl { get; set; }

      
    }
}
