namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Client : BaseDeletableModel<int>
    {

        public string Name { get; set; }

    }
}
