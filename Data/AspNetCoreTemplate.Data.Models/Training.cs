namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;
    using AspNetCoreTemplate.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    {
        public Training()
        {
            this.Promoters = new HashSet<Promoter>();
        }

        public string Name { get; set; }

        public string File { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<Promoter> Promoters { get; set; }
    }
}
