﻿using FluentValidation;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        private KaficiProjekatDbContext _context;

        public UpdateCategoryValidator(KaficiProjekatDbContext context)
        {
            _context = context;


            RuleFor(x => x.Name)
               .Cascade(CascadeMode.Stop)
               //.NotEmpty().WithMessage("Name is required.")
               .MinimumLength(3).WithMessage("Minimum length for a category name is 3.")
               .Must((x, y) => !context.Categories.Any(s => s.Name == x.Name || s.Id != x.Id)).WithMessage("Name: {PropertyValue} is already in use");

        }

        private bool CatNotInUse(string name)
        {
            var exists = _context.Categories.Any(x => x.Name == name);

            return !exists;
        }

    }
}
