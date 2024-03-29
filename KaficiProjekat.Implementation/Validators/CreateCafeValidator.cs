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
    public class CreateCafeValidator : AbstractValidator<CreateCafeDTO>
    {

        private KaficiProjekatDbContext _context;


        public CreateCafeValidator(KaficiProjekatDbContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Minimum length for a shift name is 3.")
                .Must(CafeNotInUse).WithMessage("Name: {PropertyValue} is already in use");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(3).WithMessage("Minimum length for a description is 3.");

            RuleFor(x => x.Adress)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Adress is required.")
                .MinimumLength(3).WithMessage("Minimum length for adress is 3.")
                .Must(AdressNotInUse).WithMessage("Adress: {PropertyValue} is already in use");

            _context = context;
        }

        private bool CafeNotInUse(string name)
        {
            
            
            var exists = _context.Cafes.Any(x => x.Name == name);

            return !exists;
        }

        private bool AdressNotInUse(string adress)
        {
            var exists = _context.Cafes.Any(x => x.Adress == adress);

            return !exists;
        }

    }
}
