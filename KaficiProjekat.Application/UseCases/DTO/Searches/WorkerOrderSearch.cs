using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO.Searches
{
    public class WorkerOrderSearch : BasePagedSearch
    {
        public int WorkerId { get; set; }
        public DateTime? DateFrom { get; set; } = DateTime.Today;
        public DateTime? DateTo { get; set; } = DateTime.Today.AddDays(1);
    }
}
