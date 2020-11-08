namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexProjectsViewModel : IMapFrom<Data.Models.Project>
    {
        public string Name { get; set; }

        public int Year { get; set; }
    }
}
