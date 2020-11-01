namespace AspNetCoreTemplate.Data.Models
{
    using AspNetCoreTemplate.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    { 
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
