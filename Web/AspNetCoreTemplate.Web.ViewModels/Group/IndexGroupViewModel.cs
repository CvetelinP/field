namespace AspNetCoreTemplate.Web.ViewModels.Group
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Services.Mapping;

    public class IndexGroupViewModel : IMapFrom<Data.Models.Group>
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[A-Z]+[0-9]{3}-[0-9]{2}", ErrorMessage = "Invalid Group,Example:BF020-20")]
        public string Name { get; set; }
    }
}
