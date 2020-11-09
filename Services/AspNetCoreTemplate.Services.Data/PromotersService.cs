namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public class PromotersService : IPromotersService
    {
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;

        public PromotersService(IDeletableEntityRepository<Promoter> promoteRepository)
        {
            this.promoteRepository = promoteRepository;

        }

        public async Task CreateAsync(AddPromoterInputModel model)
        {
            var genderEnum = Enum.Parse<Gender>(model.Gender);
            var promoter = new Promoter
            {
                ProjectId = model.ProjectId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                Gender = genderEnum,
                Skills = model.Skills,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = model.Language,
                ImageUrl = model.ImageUrl,
                City = model.City,
            };

            await this.promoteRepository.AddAsync(promoter);
            await this.promoteRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var promoter = this.promoteRepository.All()
                 .Where(x => x.Id == id).To<T>().FirstOrDefault();
            return promoter;
        }
    }
}
