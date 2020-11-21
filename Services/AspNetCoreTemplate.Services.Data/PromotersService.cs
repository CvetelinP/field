using AspNetCoreTemplate.Data;
using Microsoft.EntityFrameworkCore;

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
        private readonly ApplicationDbContext db;

        public PromotersService(IDeletableEntityRepository<Promoter> promoteRepository,
            IDeletableEntityRepository<Group> groupRepository, ApplicationDbContext db)
        {
            this.promoteRepository = promoteRepository;
            this.groupRepository = groupRepository;
            this.db = db;
        }

        public async Task CreateAsync(IndexPromoterViewModel model)
        {
            var promoter = new Promoter
            {
                GroupId = model.GroupId,
                ProjectId = model.ProjectId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                Gender = model.Gender,
                Skills = model.Skills,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = model.Language,
                ImageUrl = model.ImageUrl,
                City = model.City,
                District = model.District,
               
            };
            foreach (var file in model.Gallery)
            {
                promoter.PromoterGalleries.Add(new PromoterGallery
                {
                    Name = file.Name,
                    Url = file.Url,
                });
            }
            
            await this.promoteRepository.AddAsync(promoter);
            await this.promoteRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.promoteRepository.All();

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var promoter = this.promoteRepository.All()
                .Where(x => x.Id == id).To<T>().FirstOrDefault();
  
            return promoter;
        }
    }
}