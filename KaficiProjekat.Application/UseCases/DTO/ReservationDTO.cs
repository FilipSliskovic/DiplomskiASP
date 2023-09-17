using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO
{
    public class ReservationDTO : BaseDTO
    {

        public string User { get; set; }
        public string Table { get; set; }
        public string CafeName { get; set; }
        public string CafeAdress { get; set; }
        public int TableSeats { get; set; }
        public DateTime ReservationDateTime { get; set; }

    }
    public class CreateReservationDTO
    {
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDateTime { get; set; }
    }
}
