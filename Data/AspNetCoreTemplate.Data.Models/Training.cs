namespace AspNetCoreTemplate.Data.Models
{
    using System.Collections.Generic;
    using AspNetCoreTemplate.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    {
       

        public string Name { get; set; }

        public string File { get; set; }

        

       
    }
}
