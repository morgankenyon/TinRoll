using System;

namespace Tinroll.Model.User 
{
    public class UserDto
    {
        public Guid UserId {get;set;}
        public string UserName {get;set;}
        public string Email {get;set;}
        public string Description {get;set;}
    }
}