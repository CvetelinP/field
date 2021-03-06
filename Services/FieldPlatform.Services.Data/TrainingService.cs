﻿namespace FieldPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Mapping;
    using FieldPlatformWeb.ViewModels.Training;

    public class TrainingService : ITrainingService
    {
        private readonly IDeletableEntityRepository<Training> trainingRepository;

        public TrainingService(IDeletableEntityRepository<Training> trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }

        public async Task CreateAsync(IndexTrainingInputModel model)
        {
            var training = new Training
            {
                ProjectId = model.ProjectId,
                Name = model.Name,
                TrainingPdfUrl = model.TrainingPdfUrl,
                CreatedOn = DateTime.UtcNow,
            };

            await this.trainingRepository.AddAsync(training);
            await this.trainingRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.trainingRepository.All();

            return query.To<T>().ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.trainingRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var query = this.trainingRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);
            return query.To<T>().ToList();
        }

        public int GetCount()
        {
            return this.trainingRepository.All().Count();
        }

        public IEnumerable<T> Search<T>(string search)
        {
            var query = this.trainingRepository.AllAsNoTracking()
                .Where(x => x.Name.Contains(search));
            return query.To<T>().ToList();
        }
    }
}
