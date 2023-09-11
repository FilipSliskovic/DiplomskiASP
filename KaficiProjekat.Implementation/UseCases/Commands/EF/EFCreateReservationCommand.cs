using FluentValidation;
using KaficiProjekat.Application.UseCases.Commands;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.DataAccess;
using KaficiProjekat.DataAccess.Exceptions;
using KaficiProjekat.Domain;
using KaficiProjekat.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Commands.EF
{
    public class EFCreateReservationCommand : EfUseCase, ICreateReservationCommand
    {

        private CreateReservationValidator _validator;

        public EFCreateReservationCommand(KaficiProjekatDbContext context, CreateReservationValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 42;

        public string Name => "Create a new Reservation";

        public string Description => "Create a new Reservation using EF";

        public void Execute(CreateReservationDTO request)
        {
            _validator.ValidateAndThrow(request);

            var user = Context.Users.Find(request.UserId);

            var table = Context.Tables.Find(request.TableId);

            if(table  == null || user == null)
            {
                throw new EntityNotFoundException();
            }

            var reservation = new Reservation
            {
                TableId = request.TableId,
                ReservationDateTime = request.ReservationDateTime,
                UserId = request.UserId,
            };

            Context.Reservations.Add(reservation);
            Context.SaveChanges();
        }
    }
}
