namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Client : BaseDeletableModel<int>
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
