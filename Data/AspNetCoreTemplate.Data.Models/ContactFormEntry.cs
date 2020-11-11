using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreTemplate.Data.Common.Models;

namespace AspNetCoreTemplate.Data.Models
{
    public class ContactFormEntry:BaseModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Ip { get; set; }
    }
}
