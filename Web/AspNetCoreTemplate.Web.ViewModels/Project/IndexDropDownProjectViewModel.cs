using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexDropDownProjectViewModel : IMapFrom<Data.Models.Project>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
