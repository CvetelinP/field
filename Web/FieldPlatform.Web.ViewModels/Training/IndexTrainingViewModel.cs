namespace FieldPlatformWeb.ViewModels.Training
{
    using System;
    using System.Collections.Generic;

    using FieldPlatform.Web.ViewModels.Paging;
    using FieldPlatform.Web.ViewModels.Training;

    public class IndexTrainingViewModel:PagingViewModel
    {
        public IEnumerable<IndexTrainingInputModel> Trainings { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.TrainingsCount / this.ItemsPerPage);

        public int TrainingsCount { get; set; }
    }
}
