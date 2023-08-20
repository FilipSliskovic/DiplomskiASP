using KaficiProjekat.Application.UseCases.DTO;
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
    public class EFGetSingleProductQuery : EfUseCase, IGetSingleProductQuery
    {
        public EFGetSingleProductQuery(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 40;

        public string Name => "GET single product query";

        public string Description => "GET single product using EF";

        public ProductDTO Execute(int search)
        {
            var Product = Context.Products.Include(x => x.Images).Include(x => x.Category);
            var product = Product.First(x=>x.Id == search);

            var response = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Amount = product.Amount,
                CategoryName = product.Category.Name,
                Price = product.Price,
                ImageNames = product.Images.Select(x=>x.Path).ToArray(),
                
            };

            return response;
        }
    }
}
