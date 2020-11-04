using AspNetCoreTemplate.Services.Mapping;

namespace AspNetCoreTemplate.Web.ViewModels
{
    public class IndexGroupViewModel : IMapFrom<Data.Models.Group>
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
