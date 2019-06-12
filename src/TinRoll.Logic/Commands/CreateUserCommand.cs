using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;

namespace TinRoll.Logic.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; set; }
    }
}
