using FieldPlatformWeb.ViewModels.Paging;

namespace FieldPlatform.Web.ViewModels.Promoter
{
    using System;
    using System.Collections.Generic;

    public class IndexViewModel : PagingViewModel
    {
        public IEnumerable<IndexPromoterViewModel> Promoters { get; set; }

    }
}
