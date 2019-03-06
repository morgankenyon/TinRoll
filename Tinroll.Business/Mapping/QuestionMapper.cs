using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class QuestionMapper
    {
        public static QuestionDto ToDto(Question question, bool fullMapping = true) => new QuestionDto
        {
            QuestionId = question.QuestionId,
            QuestionText = question.QuestionText,
            CreatedDate = question.CreatedDate,
            ModifiedDate = question.ModifiedDate,
            User = fullMapping && question.User != null ? UserMapper.ToDto(question.User) : null
        };

        public static Question ToEntity(QuestionDto questionDto, bool fullMapping = true) => new Question
        {
            QuestionId = questionDto.QuestionId,
            QuestionText = questionDto.QuestionText,
            CreatedDate = questionDto.CreatedDate,
            ModifiedDate = questionDto.ModifiedDate,
            User = fullMapping && questionDto.User != null ? UserMapper.ToEntity(questionDto.User) : null
        };
    }
}