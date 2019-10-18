using System;
using System.Collections.Generic;
using System.Text;
using TinRoll.Data.Entities;
using TinRoll.Shared.Dtos;

namespace TinRoll.Logic.Mappers
{
    public static class AnswerMapper
    {

        public static AnswerDto ToDto(this Answer answer) => answer == null ? null :
            new AnswerDto
            {
                Id = answer.Id,
                //Content = answer.Content,
                CreatedDate = answer.CreatedDate,
                UpdatedDate = answer.UpdatedDate,
                QuestionId = answer.QuestionId,
                UserId = answer.UserId
            };

        public static (Answer, AnswerPost) ToDb(this AnswerDto answerDto) => answerDto == null ? (null,null) :
            (new Answer
            {
                Id = answerDto.Id,
                CreatedDate = answerDto.CreatedDate,
                UpdatedDate = answerDto.UpdatedDate,
                QuestionId = answerDto.QuestionId,
                UserId = answerDto.UserId
            },
            answerDto.PostDto.ToDb(answerDto.Id));

        private static AnswerPost ToDb(this PostDto postDto, int answerId) => postDto == null ? null :
            new AnswerPost
            {
                Id = postDto.Id,
                AnswerId = answerId,
                Content =  postDto.Content,
                CreatedDate = postDto.CreatedDate, //should I remove these fields so they never get updated?
                UpdatedDate = postDto.UpdatedDate,
                UserId = postDto.UserId
            };
    }
}
