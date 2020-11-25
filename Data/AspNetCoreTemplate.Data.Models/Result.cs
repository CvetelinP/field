namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Result:BaseDeletableModel<int>
    {
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string AnswerText { get; set; }
    }
}
