using Abp.AutoMapper;
using CelebrationManager.Categories.Dto;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.WorkingTimes;
using CelebrationManager.EventTimes.Dto;
using CelebrationManager.WorkingTimes.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Dto
{
    [AutoMapTo(typeof(Celebration))]
    public class CreateCelebrationDto
    {
        [Required]
        public string Header { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public EventTimeDto EventTime { get; set; }

        [Required]
        public IList<CategoryDto> Categories { get; set; }

        [Required]
        public IList<WorkingTimeDto> WorkingTimes { get; set; }

        [Required]
        public IList<IFormFile> Files { get; set; }

        public CreateCelebrationDto()
        {
            Categories = new List<CategoryDto>();
            WorkingTimes = new List<WorkingTimeDto>();
        }
    }
}
