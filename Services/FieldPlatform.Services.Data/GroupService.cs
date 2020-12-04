namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Mapping;

    public class GroupService : IGroupService
    {
        private readonly IDeletableEntityRepository<Group> groupRepository;

        public GroupService(IDeletableEntityRepository<Group> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Group> query = this.groupRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.groupRepository.All().Select(x => new
            {
                x.Id,
                x.Name,

            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var query = this.groupRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);
            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.groupRepository.All().Count();
        }
    }
}
