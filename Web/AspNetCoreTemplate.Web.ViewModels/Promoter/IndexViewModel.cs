namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System;
    using System.Collections.Generic;

    using AspNetCoreTemplate.Web.ViewModels.Paging;

    public class IndexViewModel : PagingViewModel
    {
        public IEnumerable<IndexPromoterViewModel> Promoters { get; set; }

    }
}
