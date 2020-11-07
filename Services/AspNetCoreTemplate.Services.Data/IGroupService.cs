using System.Collections.Generic;

namespace AspNetCoreTemplate.Services.Data
{
    public interface IGroupService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
