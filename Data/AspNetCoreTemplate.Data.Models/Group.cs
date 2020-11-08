namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Group : BaseDeletableModel<int>
    {

        public string Name { get; set; }

    }
}
