﻿using AnimeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Application.DTOs
{
    public class AnimeShowDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<Cast>? Casts { get; set; }
    }
}