namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Project;

    public interface IProjectService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task CreateAsync(IndexProjectsInputModel model);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();
    }
}
