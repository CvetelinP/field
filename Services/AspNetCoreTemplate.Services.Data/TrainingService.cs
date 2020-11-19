﻿namespace AspNetCoreTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Training;

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
            };
            await this.trainingRepository.AddAsync(training);
            await this.trainingRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.trainingRepository.All();

            return query.To<T>().ToList();
        }
    }
}
