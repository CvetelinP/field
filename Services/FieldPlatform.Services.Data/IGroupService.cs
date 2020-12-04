namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;

    public interface IGroupService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();
    }
}
