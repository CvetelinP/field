namespace AspNetCoreTemplate.Services.Data
{
    using System.Linq;
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class PromotersService : IPromotersService
    {
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly ApplicationDbContext db;

        public PromotersService(IDeletableEntityRepository<Promoter> promoteRepository, ApplicationDbContext db)
        {
            this.promoteRepository = promoteRepository;
            this.db = db;
        }

        public T GetById<T>(int id)
        {
            var promoter = this.promoteRepository.All()
                 .Where(x => x.Id == id).To<T>().FirstOrDefault();

            return promoter;
        }
    }
}
