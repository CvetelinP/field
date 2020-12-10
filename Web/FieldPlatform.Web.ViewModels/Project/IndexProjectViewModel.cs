namespace FieldPlatformWeb.ViewModels.Project
{
    using System;
    using System.Collections.Generic;

    using FieldPlatformWeb.ViewModels.Paging;

    public class IndexProjectViewModel : PagingViewModel
    {
        public IEnumerable<IndexProjectsInputModel> Projects { get; set; }

        public int ProjectsCount { get; set; }
    }
}
