using System;

namespace Tinroll.Model.Dto.Entity
{
    public class QuestionDto : BaseEntityDto
    {
        public Guid QuestionId {get;set;}
        public string QuestionText {get;set;}
        public Guid UserId {get;set;}
    }
}