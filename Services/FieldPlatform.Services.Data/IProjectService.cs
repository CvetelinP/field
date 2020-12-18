namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FieldPlatformWeb.ViewModels.Project;

    public interface IProjectService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task CreateAsync(IndexProjectsInputModel model);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();

        IEnumerable<T> Search<T>(string search);
    }
}