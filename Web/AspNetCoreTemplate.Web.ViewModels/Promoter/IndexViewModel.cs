namespace FieldPlatform.Web.ViewModels.Promoter
{
    using System;
    using System.Collections.Generic;

    using FieldPlatform.Web.ViewModels.Paging;

    public class IndexViewModel : PagingViewModel
    {
        public IEnumerable<IndexPromoterViewModel> Promoters { get; set; }

    }
}
