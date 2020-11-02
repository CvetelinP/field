using System.Collections.Generic;
using AspNetCoreTemplate.Data.Common.Models;

namespace AspNetCoreTemplate.Data.Models
{
    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Promoters = new HashSet<Promoter>();
        }

        public string Name { get; set; }

        public ICollection<Promoter> Promoters { get; set; }

    }
}
