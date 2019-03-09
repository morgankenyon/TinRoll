using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class AnswerMapper
    {
        public static AnswerDto ToDto(Answer answer, bool fullMapping = true) 
        {
            if (answer == null) {
                return null;
            }
            return new AnswerDto {
                AnswerId = answer.AnswerId,
                AnswerText = answer.AnswerText,
                CreatedDate = answer.CreatedDate,
                ModifiedDate = answer.ModifiedDate,
                QuestionId = answer.QuestionId,
                UserId = answer.UserId,
            };
        }

        public static Answer ToEntity(AnswerDto answerDto, bool fullMapping = true)
        {
            if (answerDto == null) {
                return null;
            }

            return new Answer {
                AnswerId = answerDto.AnswerId,
                AnswerText = answerDto.AnswerText,
                CreatedDate = answerDto.CreatedDate,
                ModifiedDate = answerDto.ModifiedDate,
                QuestionId = answerDto.QuestionId,
                UserId = answerDto.UserId,
            };
        }
    }

}