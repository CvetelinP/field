namespace FieldPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FieldPlatformWeb.ViewModels.Training;

    public interface ITrainingService
    {
        Task CreateAsync(IndexTrainingInputModel model);

        IEnumerable<T> GetAll<T>();

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();
    }
}
