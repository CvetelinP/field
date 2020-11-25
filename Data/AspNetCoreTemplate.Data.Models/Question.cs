namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Question : BaseDeletableModel<int>
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.Options = new HashSet<Option>();
            this.Results = new HashSet<Result>();
        }

        public int TrainingId { get; set; }

        public Training Training { get; set; }

        public string Description { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<Option> Options { get; set; }

        public ICollection<Result> Results { get; set; }


    }
}
