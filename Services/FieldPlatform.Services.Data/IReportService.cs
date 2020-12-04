namespace FieldPlatform.Services.Data
{
    using System.Threading.Tasks;

    using FieldPlatformWeb.ViewModels.Report;

    public interface IReportService
    {
        ReportViewModel GetById(int trainingId);
    }
}
