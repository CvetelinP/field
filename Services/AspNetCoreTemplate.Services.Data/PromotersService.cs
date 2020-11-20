namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;

    public class PromotersService : IPromotersService
    {
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly IDeletableEntityRepository<Group> groupRepository;

        public PromotersService(IDeletableEntityRepository<Promoter> promoteRepository, IDeletableEntityRepository<Group> groupRepository)
        {
            this.promoteRepository = promoteRepository;
            this.groupRepository = groupRepository;
        }

        public async Task CreateAsync(IndexPromoterViewModel model)
        {
            var genderEnum = Enum.Parse<Gender>(model.Gender);
            var cityAsEnum = Enum.Parse<City>(model.City);
            var languageAsEnum = Enum.Parse<Language>(model.Language);
            var promoter = new Promoter
            {
                GroupId = model.GroupId,
                ProjectId = model.ProjectId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                Gender = genderEnum,
                Skills = model.Skills,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = languageAsEnum,
                ImageUrl = model.ImageUrl,
                City = cityAsEnum,
                District = model.District,
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

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.promoteRepository.All();

            return query.To<T>().ToList();
        }
    }
}
