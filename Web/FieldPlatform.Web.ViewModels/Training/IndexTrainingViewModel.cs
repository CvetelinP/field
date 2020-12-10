namespace FieldPlatformWeb.ViewModels.Training
{
    using System;
    using System.Collections.Generic;

    using FieldPlatformWeb.ViewModels.Paging;

    public class IndexTrainingViewModel:PagingViewModel
    {
        public IEnumerable<IndexTrainingInputModel> Trainings { get; set; }

    }
}
