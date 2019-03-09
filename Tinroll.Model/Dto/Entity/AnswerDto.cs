using System;

namespace Tinroll.Model.Dto.Entity 
{
    public class AnswerDto : BaseEntityDto
    {   
        public Guid AnswerId {get;set;}
        public string AnswerText {get;set;}
        public Guid QuestionId {get;set;}
        public Guid UserId {get;set;}
    }
}