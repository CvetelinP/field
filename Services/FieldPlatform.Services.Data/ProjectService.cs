namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Web.ViewModels.Project;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projectEntityRepository;
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly ApplicationDbContext db;

        public ProjectService(IDeletableEntityRepository<Project> projectEntityRepository, IDeletableEntityRepository<Promoter> promoteRepository, ApplicationDbContext db)
        {
            this.projectEntityRepository = projectEntityRepository;
            this.promoteRepository = promoteRepository;
            this.db = db;
        }

        public async Task CreateAsync(IndexProjectsInputModel model)
        {
            var project = new Project
            {
                ClientId = model.ClientId,
                Name = model.Name,
                Year = model.Year,
                Description = model.Description,
            };
            await this.projectEntityRepository.AddAsync(project);
            await this.projectEntityRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Project> query = this.projectEntityRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.projectEntityRepository.All().Select(x => new
            {
                x.Id,
                x.Name,

            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var query = this.projectEntityRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);
            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.projectEntityRepository.All().Count();
        }

    }
}
