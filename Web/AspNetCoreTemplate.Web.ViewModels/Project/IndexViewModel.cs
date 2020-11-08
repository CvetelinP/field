namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexProjectsViewModel> Projects { get; set; }
    }
}
