namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public interface IPromotersService
    {
        Task CreateAsync(IndexPromoterViewModel model);
        Task CreateAsyncEdit(IndexPromoterViewModel model);

        IndexPromoterViewModel GetById(int id);
        EditPromoterViewModel GetByIdEdit(int id);

        IEnumerable<T> GetAll<T>();
    }
}
 