using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class AnswerMapper
    {
        public static AnswerDto ToDto(Answer answer, bool fullMapping) => new AnswerDto
        {

        };

        public static Answer ToEntity(AnswerDto answerDto, bool fullMapping) => new Answer
        {

        };
    }

}