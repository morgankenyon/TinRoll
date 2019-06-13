using MediatR;
using TinRoll.Data.Entities;

namespace TinRoll.Logic.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }
        public User User { get; set; }
    }
}
