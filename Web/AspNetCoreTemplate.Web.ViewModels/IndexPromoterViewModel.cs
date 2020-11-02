namespace AspNetCoreTemplate.Web.ViewModels
{
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexPromoterViewModel:IMapFrom<Data.Models.Promoter>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

    }
}