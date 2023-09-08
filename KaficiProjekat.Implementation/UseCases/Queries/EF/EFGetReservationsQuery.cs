using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.Application.UseCases.DTO.Searches;
using KaficiProjekat.Application.UseCases.Queries;
using KaficiProjekat.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Queries.EF
{
    public class EFGetReservationsQuery : EfUseCase, IGetReservationsQuery
    {
        public EFGetReservationsQuery(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Get Reservations";

        public string Description => "Get reservations using EF";

        public PagedResponse<ReservationDTO> Execute(ReservationSearch search)
        {
            var query = Context.Reservations.Where(x=>x.IsActive == true).Include(x=>x.User).Where(x=>x.IsActive == true).Include(x=>x.Table).Where(x=>x.IsActive == true);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.User.Name.Contains(search.Keyword) || x.User.LastName.Contains(search.Keyword) || x.Table.Name.Contains(search.Keyword));
            }

            if(search.UserId > 0)
            {
                query = query.Where(x=>x.User.Id ==  search.UserId);
            }

            if(search.DateFrom != null || search.DateTo != null) 
            {
                query = query.Where(x => x.ReservationDateTime >= search.DateFrom && x.ReservationDateTime <= search.DateTo);
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 15;
            }


            if (search.Page == null || search.Page < 1)
            {
                search.Page = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<ReservationDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ReservationDTO
            {
                Id = x.Id,
                User = x.User.Name + " " + x.User.LastName,
                Table = x.Table.Name,
                ReservationDateTime = x.ReservationDateTime,
                
                
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();

            return response;
        }
    }
}
