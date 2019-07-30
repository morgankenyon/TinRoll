//using System;
//using System.Collections.Generic;
//using System.Text;
//using TinRoll.Data.Entities;
//using TinRoll.Logic.Mapper;
//using TinRoll.Shared;
//using Xunit;

//namespace TinRoll.Test.Mapper
//{
//    public class QuestionMapperTests
//    {
//        [Fact]
//        public void Test_Question_ToQuestionDto()
//        {
//            var question = new Question
//            {
//                Id = 1,
//                Title = "Question Title",
//                Text = "Question Text",
//                CreatedDate = DateTime.UtcNow,
//                UpdatedDate = DateTime.UtcNow,
//                UserId = 1
//            };

//            var questionDto = QuestionMapper.ToDto(question);

//            Assert.NotNull(questionDto);
//            Assert.Equal(question.Id, questionDto.Id);
//            Assert.Equal(question.Title, questionDto.Title);
//            Assert.Equal(question.Text, questionDto.Text);
//            Assert.Equal(question.CreatedDate, questionDto.CreatedDate);
//            Assert.Equal(question.UpdatedDate, questionDto.UpdatedDate);
//            Assert.Equal(question.UserId, questionDto.UserId);
//        }

//        [Fact]
//        public void Test_QuestionDto_To_Question()
//        {
//            var questionDto = new QuestionDto
//            {
//                Id = 1,
//                Title = "Question Title",
//                Text = "Question Text",
//                CreatedDate = DateTime.UtcNow,
//                UpdatedDate = DateTime.UtcNow,
//                UserId = 1
//            };

//            var question = QuestionMapper.ToDb(questionDto);

//            Assert.NotNull(question);
//            Assert.Equal(questionDto.Id, question.Id);
//            Assert.Equal(questionDto.Title, question.Title);
//            Assert.Equal(questionDto.Text, question.Text);
//            Assert.Equal(questionDto.CreatedDate, question.CreatedDate);
//            Assert.Equal(questionDto.UpdatedDate, question.UpdatedDate);
//            Assert.Equal(questionDto.UserId, question.UserId);
//        }
//    }
//}
