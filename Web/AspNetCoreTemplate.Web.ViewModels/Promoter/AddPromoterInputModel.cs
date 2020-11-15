namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Project;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class AddPromoterInputModel : IMapFrom<Data.Models.Promoter>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(12)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(12)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public Skills Skills { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Mobile { get; set; }

        [Required]
        [Range(18, 35)]
        public int Age { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(8)]
        public string Language { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string City { get; set; }

        public string District { get; set; }

        [Display(Name ="Projects")]
        [Range(1, int.MaxValue)]
        public int ProjectId { get; set; }

        public IEnumerable<PromoterGroupInputModel> Groups { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ProjectsItems { get; set; }
    }
}
