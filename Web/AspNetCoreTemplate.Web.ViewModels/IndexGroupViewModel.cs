namespace AspNetCoreTemplate.Web.ViewModels
{
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexGroupViewModel : IMapFrom<Data.Models.Group>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
