using KaficiProjekat.Application.Exceptions;
using KaficiProjekat.Application.UseCases.Commands;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Commands.EF
{
    public class EFUpdateReservationCommand : EfUseCase, IUpdateReservationCommand
    {
        public EFUpdateReservationCommand(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 44;

        public string Name => "Update Reservation";

        public string Description => "Update reservation using EF";

        public void Execute(UpdateReservationDTO request)
        {
            var reservationToUpdate = Context.Reservations.Find(request.ID);

            if (reservationToUpdate == null)
            {
                throw new EntityNotFoundException("Reservation", request.ID);
            }

            if (Context.Tables.Find(request.TableId) == null)
            {
                throw new EntityNotFoundException("Table", request.TableId);
            }

            

            reservationToUpdate.TableId = request.TableId;

            reservationToUpdate.ReservationDateTime = request.ReservationDateTime;

            Context.SaveChanges();
        }
    }
}
