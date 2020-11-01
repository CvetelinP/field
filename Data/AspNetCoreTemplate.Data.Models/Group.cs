using AspNetCoreTemplate.Data.Common.Models;

namespace AspNetCoreTemplate.Data.Models
{
    public class Group : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
