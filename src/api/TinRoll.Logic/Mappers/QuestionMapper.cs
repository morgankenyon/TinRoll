using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToDto(this Question question) => question == null ? null :
            new QuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                CreatedDate = question.CreatedDate,
                UpdatedDate = question.UpdatedDate,
                UserId = question.UserId,
                PostDto = question.LatestQuestionPost.ToDto()
            };

        public static Question ToDb(this QuestionDto questionDto) => questionDto == null ? null :
            new Question
            {
                Id = questionDto.Id,
                Title = questionDto.Title,
                CreatedDate = questionDto.CreatedDate,
                UpdatedDate = questionDto.UpdatedDate,
                UserId = questionDto.UserId
            };

        public static Question ToDb(this CreateQuestionDto questionDto)
        {
            if (questionDto == null)
            {
                return null;
            }

            var newQuestion = new Question
            {
                Title = questionDto.Title,
                UserId = questionDto.UserId,                
            };

            var newQuestionPost = ToDb(questionDto.Content, newQuestion);

            newQuestion.LatestQuestionPost = newQuestionPost;

            return newQuestion;
        }

        internal static QuestionPost ToDb(string content, Question question) => content == null ? null :
            new QuestionPost
            {
                Question = question,
                Content = content,
                UserId = question.UserId
            };
    }
}
