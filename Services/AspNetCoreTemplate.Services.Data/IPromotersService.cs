namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public interface IPromotersService
    {
        Task CreateAsync(AddPromoterInputModel model);
        T GetById<T>(int id);

    }
}
