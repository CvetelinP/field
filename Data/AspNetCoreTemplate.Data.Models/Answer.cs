namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Answer : BaseDeletableModel<int>
    {

        public string Name { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

    }
}
