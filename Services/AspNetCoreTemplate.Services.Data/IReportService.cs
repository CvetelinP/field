namespace FieldPlatform.Services.Data
{
    using System.Threading.Tasks;

    using FieldPlatform.Web.ViewModels.Report;

    public interface IReportService
    {
        ReportViewModel GetById(int trainingId);
    }
}
