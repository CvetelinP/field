namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projectEntityRepository;

        public ProjectService(IDeletableEntityRepository<Project> projectEntityRepository)
        {
            this.projectEntityRepository = projectEntityRepository;
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
    }
}
