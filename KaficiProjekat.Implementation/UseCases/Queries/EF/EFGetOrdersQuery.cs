using Humanizer;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.Application.UseCases.DTO.Searches;
using KaficiProjekat.Application.UseCases.Queries;
using KaficiProjekat.DataAccess;
using KaficiProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Queries.EF
{
    public class EFGetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        
        public EFGetOrdersQuery(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Get orders";

        public string Description => "Get orders with EF";

        public PagedResponse<OrdersDTO> Execute(WorkerOrderSearch search)
        {

            var query = Context.Orders
                .Where(x => x.IsActive == true)
                .Include(x => x.Table)
                .ThenInclude(x=>x.Cafe)
                .ThenInclude(x=>x.WorkersInCafe)
                .ThenInclude(x=>x.UserShift)
                .ThenInclude(x=>x.User).Where(x => x.IsActive == true)
                .AsQueryable();

            if(search.WorkerId>0)
            {
                query = query.Where(order => order.UserId == search.WorkerId);
            }

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Table.Name.Contains(search.Keyword));
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

            var response = new PagedResponse<OrdersDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new OrdersDTO
            {
                OrderId = x.Id,
                CafeName = x.Table.Cafe.Name,
                Konobar = x.User.Name + " " + x.User.LastName,
                DateAndTime = x.DateAndTime,
                TableName = x.Table.Name,


            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();
            return response;

        }
    }
}
