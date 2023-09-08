using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO.Searches
{
    public class ReservationSearch : BasePagedSearch
    {
        public int UserId { get; set; }
        public DateTime? DateFrom { get; set; } = DateTime.UtcNow;
        public DateTime? DateTo { get; set; } = DateTime.UtcNow.AddDays(1);
    }
}
