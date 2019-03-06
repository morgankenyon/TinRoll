using System;

namespace Tinroll.Model.Dto.Entity 
{
    public class UserDto : BaseEntityDto
    {
        public Guid UserId {get;set;}
        public string UserName {get;set;}
        public string Email {get;set;}
        public string Description {get;set;}
    }
}