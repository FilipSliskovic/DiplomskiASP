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
        public DateTime ReservationDateTime { get; set; }

    }
}
