using AspNetCoreTemplate.Web.ViewModels.Promoter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IPromotersService
    {
        Task CreateAsync(AddPromoterInputModel model);
        T GetById<T>(int id);

    }
}
