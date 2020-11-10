using System.Collections.Generic;
using System.Linq;
using AspNetCoreTemplate.Services.Mapping;

namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Web.ViewModels.Client;

    public class ClientsService : IClientsService
    {
        private readonly IDeletableEntityRepository<Client> clientRepository;

        public ClientsService(IDeletableEntityRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task CreateAsync(IndexClientsInputModel model)
        {
            var client = new Client
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
            };
            await this.clientRepository.AddAsync(client);
            await this.clientRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Client> query = this.clientRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.clientRepository.All().Select(x => new
            {
                x.Id,
                x.Name,

            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
