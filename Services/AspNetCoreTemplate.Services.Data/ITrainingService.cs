namespace FieldPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using FieldPlatform.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task CreateAsync(IndexTrainingInputModel model);

        IEnumerable<T> GetAll<T>();

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();
    }
}
