namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;
    using AspNetCoreTemplate.Data.Models.Enum;

    public class Promoter : BaseDeletableModel<int>
    {
        public Promoter()
        {
            this.Votes = new HashSet<Vote>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public Skills Skills { get; set; }

        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public int Mobile { get; set; }

        public int Age { get; set; }

        public Language Language { get; set; }

        public string Email { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public int? ProjectId { get; set; }

        public Project Project { get; set; }

        public City City { get; set; }

        public string District { get; set; }

        public ICollection<Vote> Votes { get; set; }

    }
}
