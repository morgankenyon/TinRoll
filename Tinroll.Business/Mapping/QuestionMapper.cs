using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class QuestionMapper
    {
        public static QuestionDto ToDto(Question question, bool fullMapping = true) 
        {
            if (question == null) {
                return null;
            }

            return new QuestionDto 
            {
                QuestionId = question.QuestionId,
                QuestionText = question.QuestionText,
                CreatedDate = question.CreatedDate,
                ModifiedDate = question.ModifiedDate,
                UserId = question.UserId,
            };
        }

        public static Question ToEntity(QuestionDto questionDto, bool fullMapping = true) 
        {
            if (questionDto == null) {
                return null;
            }

            return new Question {
                QuestionId = questionDto.QuestionId,
                QuestionText = questionDto.QuestionText,
                CreatedDate = questionDto.CreatedDate,
                ModifiedDate = questionDto.ModifiedDate,
                UserId = questionDto.UserId,
            };
        }
    }
}