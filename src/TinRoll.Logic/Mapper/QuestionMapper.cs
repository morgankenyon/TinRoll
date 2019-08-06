using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data;
using TinRoll.Shared;

namespace TinRoll.Logic.Mapper
{
    public static class QuestionMapper
    {
        public static QuestionDto ToDto(Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                Text = question.Text,
                CreatedDate = question.CreatedDate,
                UpdatedDate = question.UpdatedDate,
                UserId = question.UserId,
                User = UserMapper.ToDto(question.User)
            };
        }

        public static Question ToDb(QuestionDto questionDto)
        {
            return new Question
            {
                Id = questionDto.Id,
                Title = questionDto.Title,
                Text = questionDto.Text,
                CreatedDate = questionDto.CreatedDate,
                UpdatedDate = questionDto.UpdatedDate,
                UserId = questionDto.UserId
            };
        }
    }
}
