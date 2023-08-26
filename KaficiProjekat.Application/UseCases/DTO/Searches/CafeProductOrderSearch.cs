using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO.Searches
{
    public class CafeProductOrderSearch : BasePagedSearch
    {
        public int OrderId { get; set; }
    }
}
