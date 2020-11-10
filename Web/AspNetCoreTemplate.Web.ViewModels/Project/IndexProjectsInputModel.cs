namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Client;

    public class IndexProjectsInputModel : IMapFrom<Data.Models.Project>
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[A-Z]+[0-9]{3}-[0-9]{2}", ErrorMessage = "Invalid Group,Example:BF020-20")]
        public string Name { get; set; }

        [Range(2000, 2099)]
        public int Year { get; set; }

        [MaxLength(60)]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int ClientId { get; set; }

        public IEnumerable<IndexClientDropDownInputModel> Clients { get; set; }

    }
}
