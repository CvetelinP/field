namespace FieldPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Web.ViewModels.Promoter;

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

        public async Task CreateAsyncEdit(IndexPromoterViewModel model)
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
            await this.promoteRepository.AddAsync(promoter);
            await this.promoteRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var query = this.promoteRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);
            return query.To<T>().ToList();
        }

        public int GetCount()
        {
           return this.promoteRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var promoter = this.promoteRepository.All()
                .Where(x => x.Id == id).To<T>().FirstOrDefault();
            return promoter;
        }

        public IndexPromoterViewModel GetById(int id)
        {
            var promoter = this.db.Promoters.Where(x => x.Id == id)
              .Select(model => new IndexPromoterViewModel
              {
                  Id = model.Id,
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
                  Gallery = model.PromoterGalleries.Select(g => new GalleryPromoterViewModel
                  {
                      Id = g.Id,
                      Name = g.Name,
                      Url = g.Url,

                  }).ToList(),
              }).FirstOrDefault();

            return promoter;
        }

        public EditPromoterViewModel GetByIdEdit(int id)
        {
            var promoter = this.db.Promoters.Where(x => x.Id == id)
               .Select(model => new EditPromoterViewModel
               {
                   Id = model.Id,
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
                   Gallery = model.PromoterGalleries.Select(g => new GalleryPromoterViewModel
                   {
                       Id = g.Id,
                       Name = g.Name,
                       Url = g.Url,

                   }).ToList(),
               }).FirstOrDefault();
            return promoter;
        }
    }
}
