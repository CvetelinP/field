using System.Collections.Generic;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IProjectService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
