namespace AspNetCoreTemplate.Data.Models
{
    using AspNetCoreTemplate.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

    }
}
