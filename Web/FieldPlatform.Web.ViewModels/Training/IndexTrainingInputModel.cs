﻿namespace FieldPlatformWeb.ViewModels.Training
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FieldPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class IndexTrainingInputModel : IMapFrom<FieldPlatform.Data.Models.Training>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        [Display(Name = "Upload your Presentation in pdf format")]
        [Required]
        public IFormFile TrainingPdf { get; set; }

        public string TrainingPdfUrl { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ProjectsItems { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
