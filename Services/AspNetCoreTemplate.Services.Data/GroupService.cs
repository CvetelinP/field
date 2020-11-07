using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;

namespace AspNetCoreTemplate.Services.Data
{
    public class GroupService : IGroupService
    {
        private readonly IDeletableEntityRepository<Group> groupRepository;

        public GroupService(IDeletableEntityRepository<Group> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var query = this.groupRepository.All().OrderBy(x => x.Name);

            return query.To<T>().ToList();
        }
    }
}
