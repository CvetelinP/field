namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.Linq;

    using AspNetCoreTemplate.Services.Mapping;
    using AutoMapper;

    public class PromoterProfileViewModel : IMapFrom<Data.Models.Promoter>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Skills { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        public int Mobile { get; set; }

        public int Age { get; set; }

        public string Language { get; set; }

        public string Email { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Promoter, PromoterProfileViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
