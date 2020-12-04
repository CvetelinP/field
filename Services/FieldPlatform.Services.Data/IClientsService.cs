namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FieldPlatform.Web.ViewModels.Client;
    using FieldPlatformWeb.ViewModels.Client;

    public interface IClientsService
    {
        Task CreateAsync(IndexClientsInputModel model);

        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();
    }
}
