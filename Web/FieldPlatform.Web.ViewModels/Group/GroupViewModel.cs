namespace FieldPlatformWeb.ViewModels.Group
{
    using System.Collections.Generic;

    using FieldPlatformWeb.ViewModels.Paging;

    public class GroupViewModel:PagingViewModel
    {
        public IEnumerable<IndexGroupViewModel> Groups { get; set; }

    }
}
