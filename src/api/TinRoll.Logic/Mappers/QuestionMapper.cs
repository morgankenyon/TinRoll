using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToDto(Question question) => question == null ? null :
            new QuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                Content = question.Content,
                CreatedDate = question.CreatedDate,
                UpdatedDate = question.UpdatedDate,
                UserId = question.UserId
            };

        public static Question ToDb(QuestionDto questionDto) => questionDto == null ? null :
            new Question
            {
                Id = questionDto.Id,
                Title = questionDto.Title,
                Content = questionDto.Content,
                CreatedDate = questionDto.CreatedDate,
                UpdatedDate = questionDto.UpdatedDate,
                UserId = questionDto.UserId
            };

        public static Question ToDb(CreateQuestionDto questionDto) => questionDto == null ? null : new Question
            {
                Title = questionDto.Title,
                Content = questionDto.Content,
                UserId = questionDto.UserId
            };
    }
}
