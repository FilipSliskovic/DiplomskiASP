using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Application.UseCases.DTO.Searches
{
    public class CafeProductsSearch : BasePagedSearch
    {
        public string CafeName { get; set; }
    }
}
