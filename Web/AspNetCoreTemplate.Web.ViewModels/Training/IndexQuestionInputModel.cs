namespace AspNetCoreTemplate.Web.ViewModels.Training
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class IndexQuestionInputModel : IMapFrom<Question>
    {
        [Required]
        public string Description { get; set; }
    }
}