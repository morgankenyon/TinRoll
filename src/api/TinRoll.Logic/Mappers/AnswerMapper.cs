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

        public static Answer ToDb(this AnswerDto answerDto)
        {
            if (answerDto == null)
            {
                return null;
            }

            var answer = new Answer
            {
                Id = answerDto.Id,
                CreatedDate = answerDto.CreatedDate,
                UpdatedDate = answerDto.UpdatedDate,
                QuestionId = answerDto.QuestionId,
                UserId = answerDto.UserId
            };

            var answerPost = answerDto.PostDto.ToDb(answer);

            answer.LatestAnswerPost = answerPost;

            return answer;
        }

        internal static AnswerPost ToDb(this PostDto postDto, Answer answer) => postDto == null ? null :
            new AnswerPost
            {
                Answer = answer,
                Content =  postDto.Content,
                UserId = answer.UserId
            };
    }
}
