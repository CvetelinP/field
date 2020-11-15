namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task CreateAsync(IndexTrainingInputModel model);
        IEnumerable<T> GetAll<T>();
    }
}
