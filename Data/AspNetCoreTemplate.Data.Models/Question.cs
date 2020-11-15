namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Question : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int TrainingId { get; set; }

        public Training Training { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
}
