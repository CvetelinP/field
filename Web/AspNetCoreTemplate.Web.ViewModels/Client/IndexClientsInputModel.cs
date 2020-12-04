namespace FieldPlatform.Web.ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;

    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Data.Models;

    public class IndexClientsInputModel : IMapFrom<Client>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
