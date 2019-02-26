using Tinroll.Model.User;

namespace Tinroll.Model.Question
{
    public class QuestionDto
    {
        public int QuestionId {get;set;}
        public string QuestionText {get;set;}
        public UserDto User {get;set;}
    }
}