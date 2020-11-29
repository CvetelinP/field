namespace AspNetCoreTemplate.Services.Data
{
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Report;

    public interface IReportService
    {

        Task CreateAsync(ReportViewModel model);
    }
}
