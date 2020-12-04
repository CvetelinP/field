namespace FieldPlatformWeb.ViewModels.Group
{
    using System.ComponentModel.DataAnnotations;

    using FieldPlatform.Services.Mapping;

    public class IndexGroupViewModel : IMapFrom<FieldPlatform.Data.Models.Group>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int PromotersCount { get; set; }
    }
}
