using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Categories.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
