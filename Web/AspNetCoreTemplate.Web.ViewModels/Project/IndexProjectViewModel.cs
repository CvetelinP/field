namespace FieldPlatform.Web.ViewModels.Project
{
    using System;
    using System.Collections.Generic;

    using FieldPlatform.Web.ViewModels.Paging;

    public class IndexProjectViewModel : PagingViewModel
    {
        public IEnumerable<IndexProjectsInputModel> Projects { get; set; }

        public int PagesCount => (int) Math.Ceiling((double) this.ProjectsCount / this.ItemsPerPage);

        public int ProjectsCount { get; set; }
    }
}
