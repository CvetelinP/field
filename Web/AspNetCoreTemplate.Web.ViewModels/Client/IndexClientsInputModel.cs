namespace AspNetCoreTemplate.Web.ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Services.Mapping;

    public class IndexClientsInputModel : IMapFrom<Data.Models.Client>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
