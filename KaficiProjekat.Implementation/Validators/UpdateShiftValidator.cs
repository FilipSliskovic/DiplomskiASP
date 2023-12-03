using FluentValidation;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.Validators
{
    public class UpdateShiftValidator : AbstractValidator<ShiftDTO>
    {

        private KaficiProjekatDbContext _context;

        public UpdateShiftValidator(KaficiProjekatDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required")
                .Must((x,y) => !context.Shifts.Any(s => s.Name == x.Name || s.Id != x.Id)).WithMessage("Name: {PropertyValue} is already in use");


        }

        private bool NameNotInUse(string name)
        {
            var exists = _context.Shifts.Any(x => x.Name == name);

            return !exists;
        }


    }
}
