using AspNetCoreTemplate.Data.Models;

namespace AspNetCoreTemplate.Web.ViewModels
{
    using AspNetCoreTemplate.Services.Mapping;

    public class PromoterProfileViewModel : IMapFrom<Data.Models.Promoter>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Skills { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        public int Mobile { get; set; }

        public int Age { get; set; }

        public string Language { get; set; }

        public string Email { get; set; }

        public Group Group { get; set; }
    }
}
