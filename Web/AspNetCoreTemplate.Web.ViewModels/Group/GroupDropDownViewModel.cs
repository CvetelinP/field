namespace AspNetCoreTemplate.Web.ViewModels.Group
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Services.Mapping;

    public class GroupDropDownViewModel : IMapFrom<Data.Models.Group>
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }

        
    }
}
