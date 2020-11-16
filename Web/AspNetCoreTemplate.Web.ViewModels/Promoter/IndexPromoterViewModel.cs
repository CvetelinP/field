namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Mapping;
    using AutoMapper;

    public class IndexPromoterViewModel : IMapFrom<Data.Models.Promoter>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(8)]
        public string Language { get; set; }
        public string Gender { get; set; }

        [Required]
        public int Mobile { get; set; }
        public string City { get; set; }

        public string District { get; set; }

        [Required]
        public Skills Skills { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

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