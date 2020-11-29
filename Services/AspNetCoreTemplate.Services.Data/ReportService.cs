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

        public ReportService(IDeletableEntityRepository<Report> reportRepository)
        {
            this.reportRepository = reportRepository;
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
    }
}
