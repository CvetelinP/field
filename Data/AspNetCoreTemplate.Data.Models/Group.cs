namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.Promoters = new HashSet<PromoterGroup>();
        }

        public string Name { get; set; }


        public ICollection<PromoterGroup> Promoters { get; set; }
    }
}
