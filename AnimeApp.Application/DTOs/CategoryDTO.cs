﻿using AnimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.DTOs
{
    public class BaseCategoryDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class CategoryDTO : BaseCategoryDTO
    {
        public ICollection<BaseAnimeShowDTO>? AnimeShows { get; set; }
    }
}
