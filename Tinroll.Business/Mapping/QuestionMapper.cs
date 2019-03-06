using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class QuestionMapper
    {
        public static QuestionDto ToDto(Question question) => new QuestionDto
        {
            QuestionId = question.QuestionId,
            QuestionText = question.QuestionText,
            User = question.User != null ? UserMapper.ToDto(question.User) : null
        };

        public static Question ToEntity(QuestionDto questionDto) => new Question
        {
            QuestionId = questionDto.QuestionId,
            QuestionText = questionDto.QuestionText,
            User = questionDto.User != null ? UserMapper.ToEntity(questionDto.User) : null
        };
    }
}