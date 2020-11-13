using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTemplate.Web.ViewModels.Project;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IProjectService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task CreateAsync(IndexProjectsInputModel model);

       
    }
}
