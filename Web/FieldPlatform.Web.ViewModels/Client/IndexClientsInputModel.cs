namespace FieldPlatformWeb.ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;

    using FieldPlatform.Services.Mapping;

    public class IndexClientsInputModel : IMapFrom<FieldPlatform.Data.Models.Client>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        [RegularExpression(@"[A-Z]+")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
