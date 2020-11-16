namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AspNetCoreTemplate.Services.Mapping;
    using AutoMapper;

    public class IndexPromoterViewModel : IMapFrom<Data.Models.Promoter>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public int VotesType { get; set; }

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