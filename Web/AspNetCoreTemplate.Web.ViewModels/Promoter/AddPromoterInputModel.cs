namespace AspNetCoreTemplate.Web.ViewModels.Promoter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddPromoterInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Ability { get; set; } // TODO:

        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        public int Mobile { get; set; }

        public int Age { get; set; }

        public string Language { get; set; }

        public string Email { get; set; }
    }
}
