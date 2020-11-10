using System.Collections.Generic;

namespace AspNetCoreTemplate.Services.Data
{
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Client;

    public interface IClientsService
    {
        Task CreateAsync(IndexClientsInputModel model);

        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
