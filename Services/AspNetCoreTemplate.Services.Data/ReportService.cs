

using System.Linq;
using AspNetCoreTemplate.Data;

namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Web.ViewModels.Report;

    public class ReportService : IReportService
    {
        private readonly IDeletableEntityRepository<Report> reportRepository;
        private readonly ApplicationDbContext db;

        public ReportService(IDeletableEntityRepository<Report> reportRepository,ApplicationDbContext db)
        {
            this.reportRepository = reportRepository;
            this.db = db;
        }

        public async Task CreateAsync(ReportViewModel model)
        {
            var report = new Report
            {
                ReportUrl = model.ReportUrl,
                TrainingId = model.TrainingId,
            };
            foreach (var file in model.Gallery)
            {
                report.ReportGalleries.Add(new ReportGallery
                {
                    Name = file.Name,
                    Url = file.Url,
                });
            }

            await this.reportRepository.AddAsync(report);
            await this.reportRepository.SaveChangesAsync();

        }

        public ReportViewModel GetById(int trainingId)
        {
            var report = this.db.Reports.Where(x => x.TrainingId == trainingId)
                .Select(model => new ReportViewModel()
                {
                    Id = model.Id,
                    TrainingId = model.TrainingId,
                    ReportUrl = model.ReportUrl,
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
