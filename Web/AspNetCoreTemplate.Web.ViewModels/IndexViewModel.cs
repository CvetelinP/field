namespace AspNetCoreTemplate.Web.ViewModels
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPromoterViewModel> Promoters { get; set; }
    }
}
