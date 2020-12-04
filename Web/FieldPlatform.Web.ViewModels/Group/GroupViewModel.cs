namespace FieldPlatformWeb.ViewModels.Group
{
    using System;
    using System.Collections.Generic;

    using FieldPlatformWeb.ViewModels.Paging;

    public class GroupViewModel:PagingViewModel
    {
        public IEnumerable<IndexGroupViewModel> Groups { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.GroupsCount / this.ItemsPerPage);

        public int GroupsCount { get; set; }
    }
}
