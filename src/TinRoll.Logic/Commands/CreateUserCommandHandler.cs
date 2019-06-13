using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TinRoll.Data;

namespace TinRoll.Logic.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        readonly TinRollContext tinRollContext;
        public CreateUserCommandHandler(TinRollContext context)
        {
            tinRollContext = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            tinRollContext.Users.Add(request.User);
            await tinRollContext.SaveChangesAsync(cancellationToken);

            return request.User.Id;
        }
    }
}