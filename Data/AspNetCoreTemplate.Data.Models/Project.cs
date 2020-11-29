namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.Promoters = new HashSet<Promoter>();
            this.Trainings = new HashSet<Training>();
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Promoter> Promoters { get; set; }

        public ICollection<Training> Trainings { get; set; }

    }
}
