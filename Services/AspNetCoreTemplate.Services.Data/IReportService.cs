namespace AspNetCoreTemplate.Services.Data
{
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Web.ViewModels.Report;

    public interface IReportService
    {

        ReportViewModel GetById(int trainingId);
    }
}
