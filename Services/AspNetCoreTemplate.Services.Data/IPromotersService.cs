namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public interface IPromotersService
    {
        Task CreateAsync(IndexPromoterViewModel model);

        T GetById<T>(int id);
        IEnumerable<T> GetAll<T>();
    }
}
