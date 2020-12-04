namespace FieldPlatformWeb.ViewModels.Training
{
    using System;
    using System.Collections.Generic;

    using FieldPlatformWeb.ViewModels.Paging;

    public class IndexTrainingViewModel:PagingViewModel
    {
        public IEnumerable<IndexTrainingInputModel> Trainings { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.TrainingsCount / this.ItemsPerPage);

        public int TrainingsCount { get; set; }
    }
}
