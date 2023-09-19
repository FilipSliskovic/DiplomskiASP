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
    public class CreateReservationValidator :AbstractValidator<CreateReservationDTO>
    {
        private KaficiProjekatDbContext _context;

        public CreateReservationValidator(KaficiProjekatDbContext context)
        {
            _context = context;

            RuleFor(x=>x.ReservationDateTime).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Date and Time are required")
                .GreaterThanOrEqualTo(DateTime.UtcNow.AddMinutes(-1)).WithMessage("Date and time must be in the present");

            //RuleFor(x => x.ReservationDateTime)
            //.Cascade(CascadeMode.Stop)
            //.Must((reservation, reservationDateTime) =>
            //{
            //    // Calculate the minimum allowed reservation time
            //    DateTime minAllowedReservationTime = reservationDateTime.AddHours(-1);

            //    // Check if there are any reservations on the same table within 1 hour
            //    return context.Reservations.Any(r =>
            //        r.TableId == reservation.TableId &&
            //        r.ReservationDateTime >= minAllowedReservationTime &&
            //        r.ReservationDateTime <= reservationDateTime);
            //})
            //.WithMessage("Reservation cannot be made within 1 hour of an existing reservation on the same table.");
        }


    }
}
