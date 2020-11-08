namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.Promoters = new HashSet<Promoter>();
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public ICollection<Promoter> Promoters { get; set; }

    }


}
