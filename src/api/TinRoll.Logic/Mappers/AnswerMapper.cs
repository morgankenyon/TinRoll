using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class AnswerMapper
    {

        public static AnswerDto ToDto(Answer answer) => answer == null ? null :
            new AnswerDto
            {
                Id = answer.Id,
                //Content = answer.Content,
                CreatedDate = answer.CreatedDate,
                UpdatedDate = answer.UpdatedDate,
                QuestionId = answer.QuestionId,
                UserId = answer.UserId
            };

        public static Answer ToDb(AnswerDto answerDto) => answerDto == null ? null :
            new Answer
            {
                Id = answerDto.Id,
                //Content = answerDto.Content,
                CreatedDate = answerDto.CreatedDate,
                UpdatedDate = answerDto.UpdatedDate,
                QuestionId = answerDto.QuestionId,
                UserId = answerDto.UserId
            };
    }
}
