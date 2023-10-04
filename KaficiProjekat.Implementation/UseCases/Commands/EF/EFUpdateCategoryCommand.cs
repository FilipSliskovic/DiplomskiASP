using KaficiProjekat.Application.Exceptions;
using KaficiProjekat.Application.UseCases.Commands;
using KaficiProjekat.Application.UseCases.DTO;
using KaficiProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaficiProjekat.Implementation.UseCases.Commands.EF
{
    public class EFUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        public EFUpdateCategoryCommand(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 45;

        public string Name => "Update category";

        public string Description => "update category using ef";

        public void Execute(UpdateCategoryDTO request)
        {
            var cat = Context.Categories.Find(request.Id);

            if (cat == null)
            {
                throw new EntityNotFoundException("Table", request.Id);
            }

            if (request.Name != null)
            {
                cat.Name = request.Name;
            }

            if(request.ParentCategoryId == cat.ParentId)
            {
                throw new UseCaseConflictException("Category cant be parent to itself");
            }

            if (request.ParentCategoryId > 0)
            {
                cat.ParentId = request.ParentCategoryId;
            }




            Context.SaveChanges();
        }
    }
}
