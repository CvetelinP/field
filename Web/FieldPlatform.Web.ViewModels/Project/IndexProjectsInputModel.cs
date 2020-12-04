namespace FieldPlatformWeb.ViewModels.Project
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FieldPlatform.Services.Mapping;

    public class IndexProjectsInputModel : IMapFrom<FieldPlatform.Data.Models.Project>
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[A-Z]+[0-9]{3}-[0-9]{2}", ErrorMessage = "Invalid Project,Example:BF020-20")]
        public string Name { get; set; }

        [Required]
        [Range(2000, 2099)]
        public int Year { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Display(Name = "Clients")]
        [Range(1, int.MaxValue)]
        public int ClientId { get; set; }

        public int PromotersCount { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ClientsItems { get; set; }

    }
}