namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System.Linq;

    using AspNetCoreTemplate.Services.Mapping;
    using AutoMapper;

    public class PromoterProfileViewModel : IndexPromoterViewModel
    {
        public int VotesCount { get; set; }
    }
}
