using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class AnswerMapper
    {
        public static AnswerDto ToDto(Answer answer, bool fullMapping = true) => new AnswerDto
        {
            AnswerId = answer.AnswerId,
            AnswerText = answer.AnswerText,
            CreatedDate = answer.CreatedDate,
            ModifiedDate = answer.ModifiedDate,
            Question = fullMapping && answer.Question != null ? QuestionMapper.ToDto(answer.Question) : null,
            User = fullMapping && answer.User != null ? UserMapper.ToDto(answer.User) : null
        };

        public static Answer ToEntity(AnswerDto answerDto, bool fullMapping = true) => new Answer
        {
            AnswerId = answerDto.AnswerId,
            AnswerText = answerDto.AnswerText,
            CreatedDate = answerDto.CreatedDate,
            ModifiedDate = answerDto.ModifiedDate,
            Question = fullMapping && answerDto.Question != null ? QuestionMapper.ToEntity(answerDto.Question)  : null,
            User = fullMapping && answerDto.User != null ? UserMapper.ToEntity(answerDto.User) : null
        };
    }

}