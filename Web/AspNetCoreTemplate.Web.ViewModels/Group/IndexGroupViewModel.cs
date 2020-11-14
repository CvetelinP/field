using System.Collections.Generic;

namespace AspNetCoreTemplate.Web.ViewModels.Group
{
    using System.ComponentModel.DataAnnotations;

    using AspNetCoreTemplate.Services.Mapping;

    public class IndexGroupViewModel : IMapFrom<Data.Models.Group>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public int PromotersCount { get; set; }
    }
}
