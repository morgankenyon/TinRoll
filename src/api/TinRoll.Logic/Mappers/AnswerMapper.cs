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
                CreatedDate = answer.CreatedDate,
                UpdatedDate = answer.UpdatedDate,
                QuestionId = answer.QuestionId,
                UserId = answer.UserId,
                PostDto = PostMapper.ToDto(answer.LatestAnswerPost)
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
            answerDto.PostDto.ToDb(answerDto));

        internal static AnswerPost ToDb(this PostDto postDto, AnswerDto answerDto) => postDto == null ? null :
            new AnswerPost
            {
                AnswerId = answerDto.Id,
                Content =  postDto.Content,
                UserId = answerDto.UserId
            };
    }
}
