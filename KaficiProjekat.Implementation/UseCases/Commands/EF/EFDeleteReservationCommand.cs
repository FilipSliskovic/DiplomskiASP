using KaficiProjekat.Application.Exceptions;
using KaficiProjekat.Application.UseCases.Commands;
using KaficiProjekat.DataAccess;
using KaficiProjekat.DataAccess.Extensions;
using KaficiProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Commands.EF
{
    public class EFDeleteReservationCommand : EfUseCase, IDeleteReservationCommand
    {
        public EFDeleteReservationCommand(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Delete Reservation";

        public string Description => "Delete reservation using EF";

        public void Execute(int request)
        {

            if (Context.Reservations.Find(request) == null)
            {
                throw new EntityNotFoundException("Reservation", request);
            }


            Context.Deactivate<Reservation>(request);

            Context.SaveChanges();
        }
    }
}
