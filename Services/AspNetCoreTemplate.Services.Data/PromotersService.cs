namespace AspNetCoreTemplate.Services.Data
{
    using System.Linq;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class PromotersService : IPromotersService
    {
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;

        public PromotersService(IDeletableEntityRepository<Promoter> promoteRepository)
        {
            this.promoteRepository = promoteRepository;
        }

        public T GetById<T>(int id)
        {
            var promoter = this.promoteRepository.All()
                 .Where(x => x.Id == id).To<T>().FirstOrDefault();

            return promoter;
        }
    }
}
