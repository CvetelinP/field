namespace FieldPlatform.Services.Data
{
    using System.Linq;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatformWeb.ViewModels.Report;

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
