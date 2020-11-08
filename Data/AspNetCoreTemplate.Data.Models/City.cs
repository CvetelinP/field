using AspNetCoreTemplate.Data.Common.Models;

namespace AspNetCoreTemplate.Data.Models
{
    public class City : BaseDeletableModel<int>
    {
 
        public string Name { get; set; }

        public string District { get; set; }

    }
}
