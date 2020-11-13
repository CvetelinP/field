using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreTemplate.Web.ViewModels.Promoter;

namespace AspNetCoreTemplate.Web.ViewModels.Project
{
    public class IndexProjectGetPromotersById
    {
        
        public ICollection<IndexPromoterViewModel> Promoters { get; set; }
    }
}
