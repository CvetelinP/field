namespace AspNetCoreTemplate.Data.Models
{
    using AspNetCoreTemplate.Data.Common.Models;

    public class Option : BaseDeletableModel<int>
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string OptionName { get; set; }
    }
}
