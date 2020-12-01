
namespace AspNetCoreTemplate.Services.Data
{
    using System.Linq;
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Web.ViewModels.Report;

    public class ReportService : IReportService
    {
        private readonly IDeletableEntityRepository<Report> reportRepository;
        private readonly ApplicationDbContext db;
        public ReportService(IDeletableEntityRepository<Report> reportRepository, ApplicationDbContext db)
        {
            this.reportRepository = reportRepository;
            this.db = db;
        }

        public ReportViewModel GetById(int trainingId)
        {
            var report = this.db.Reports.Where(x => x.TrainingId == trainingId)
                .Select(model => new ReportViewModel()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    TrainingId = model.TrainingId,
                    ReportUrl = model.ReportUrl,
                    UserUserName = model.User.UserName,
                    Gallery = model.ReportGalleries.Select(g => new GalleryReportViewModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url,

                    }).ToList(),
                }).FirstOrDefault();

            return report;
        }
    }
}
