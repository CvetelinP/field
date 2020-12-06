namespace FieldPlatform.Web.ViewModels.Promoter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Data.Models.Enum;
    using FieldPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class IndexPromoterViewModel : IMapFrom<Promoter>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        [Required]
        public string FirstName { get; set; }

        public int VotesCount { get; set; }

        public IFormFile ImagePhoto { get; set; }

        public IFormFileCollection GalleryFiles { get; set; }

        public IList<GalleryPromoterViewModel> Gallery { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Mobile { get; set; }

        [Required]      
        public City City { get; set; }

        [MinLength(1)]
        [MaxLength(40)]
        public string District { get; set; }

        [Required]
        public Skills Skills { get; set; }

        [Range(18, 55)]
        public int Age { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(400)]
        public string Description { get; set; }

        public int VotesType { get; set; }

        [Display(Name = "Projects")]
        [Range(1, int.MaxValue)]
        public int? ProjectId { get; set; }

        [Display(Name = "Groups")]
        [Range(1, int.MaxValue)]
        public int? GroupId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ProjectsItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GroupsItems { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Promoter, IndexPromoterViewModel>()
                .ForMember(x => x.VotesType, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
