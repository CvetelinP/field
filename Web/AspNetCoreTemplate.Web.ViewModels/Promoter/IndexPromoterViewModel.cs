using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexPromoterViewModel : IMapFrom<Data.Models.Promoter>
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

    }
}