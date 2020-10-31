namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;
    using AspNetCoreTemplate.Data.Models.Enum;

    public class Promoter : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Ability { get; set; } // TODO:

        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public int Mobile { get; set; }

        public int Age { get; set; }

        public string Language { get; set; }

        public string Email { get; set; }

    }
}
