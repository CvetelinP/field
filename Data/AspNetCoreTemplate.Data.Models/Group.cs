namespace FieldPlatform.Data.Models
{
    using System.Collections.Generic;

    using FieldPlatform.Data.Common.Models;

    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.Promoters = new HashSet<Promoter>();
        }

        public string Name { get; set; }

        public ICollection<Promoter> Promoters { get; set; }
    }
}
