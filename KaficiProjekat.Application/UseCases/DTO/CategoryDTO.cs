﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? ParentName {get; set;}
    }

    public class CreateCategoryDTO
    {
        public string ImageFileName { get; set; }

        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

    }

    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
