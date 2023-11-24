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
    public class EFGetCafeWorkersQuery : EfUseCase, IGetCafeWorkersQuery
    {
        public EFGetCafeWorkersQuery(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 45;

        public string Name => "Get cafe workers";

        public string Description => "get cafe workers";

        public PagedResponse<UserDTO> Execute(BasePagedSearch search)
        {
            var query = Context.UserUseCase.Where(x => x.UseCaseId == 20)
                .Include(x => x.User).Where(x=> !x.User.IsSuperUser);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.User.Name.Contains(search.Keyword) || x.User.LastName.Contains(search.Keyword) || x.User.UserName.Contains(search.Keyword));
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

            var response = new PagedResponse<UserDTO>();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new UserDTO
            {
                Id = x.User.Id,
                Username = x.User.UserName,
                Firstname = x.User.Name,
                Lastname = x.User.LastName
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            response.TotalCount = query.Count();

            return response;
        }
    }
}
