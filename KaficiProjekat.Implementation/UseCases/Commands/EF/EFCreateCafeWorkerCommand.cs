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
    public class EFCreateCafeWorkerCommand : EfUseCase, ICreateCafeWorkerCommand
    {
        public EFCreateCafeWorkerCommand(KaficiProjekatDbContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Create a new worker";

        public string Description => "create a new worker using ef";

        public void Execute(AddWorkerDTO request)
        {
            var user = Context.Users.Find(request.UserId);

            if(user == null)
            {
                throw new EntityNotFoundException("User", request.UserId);
            }

            

        }
    }
}
