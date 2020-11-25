namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public class IndexProjectGetPromotersById
    {
        public ICollection<IndexPromoterViewModel> Promoters { get; set; }
    }
}
