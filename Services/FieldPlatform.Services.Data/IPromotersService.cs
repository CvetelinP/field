namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FieldPlatform.Web.ViewModels.Promoter;

    public interface IPromotersService
    {
        Task CreateAsync(IndexPromoterViewModel model);

        Task CreateAsyncEdit(IndexPromoterViewModel model);

        IndexPromoterViewModel GetById(int id);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();

        IEnumerable<T> Search<T>(string search);
    }
}
