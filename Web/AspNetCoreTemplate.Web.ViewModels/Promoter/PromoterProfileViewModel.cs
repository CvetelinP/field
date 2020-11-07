using System.Collections.Generic;
using AspNetCoreTemplate.Web.ViewModels.Group;

namespace AspNetCoreTemplate.Web.ViewModels.Promoter
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

        public int GroupId { get; set; }

        //public IEnumerable<GroupDropDownViewModel> Groups { get; set; }

    }
}
