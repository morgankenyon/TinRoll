using Tinroll.Data.Entities;
using Tinroll.Model.Question;

namespace Tinroll.Business.Mapping
{
    public class QuestionMapper
    {
        public static QuestionDto ToDto(Question Question) => new QuestionDto
        {
            QuestionId = Question.QuestionId,
            QuestionText = Question.QuestionText,
            User = Question.User != null ? UserMapper.ToDto(Question.User) : null
        };

        public static Question ToEntity(QuestionDto questionDto) => new Question
        {
            QuestionId = questionDto.QuestionId,
            QuestionText = questionDto.QuestionText,
            //User = QuestionDto.User != null ? UserMapping.ToEntity(QuestionDto.User) : null
        };
    }
}