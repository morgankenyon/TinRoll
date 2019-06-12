using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinRoll.Data;
using TinRoll.Data.Entities;

namespace TinRoll.Logic.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        readonly TinRollContext tinRollContext;
        public CreateUserHandler(TinRollContext context)
        {
            tinRollContext = context;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            tinRollContext.Users.Add(request.User);
            await tinRollContext.SaveChangesAsync();

            return request.User;
        }
    }
}
