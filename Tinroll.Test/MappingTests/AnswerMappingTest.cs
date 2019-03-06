using System;
using Tinroll.Data.Entity;
using Xunit;

namespace Tinroll.Test.MappingTests
{
    public class AnswerMappingTest 
    {

        [Fact]
        public void MapAnswerToDto() 
        {
            //Arrange
            var user = new User {
                UserId = Guid.NewGuid(),
                UserName = "morganTest"
            };
            var question = new Question {
                QuestionId = Guid.NewGuid(),
                User = user
            };

            var answer = new Answer 
            {
                AnswerId = Guid.NewGuid(),
                AnswerText = "Answer text",
                CreatedDate = DateTime.Today,
                ModifiedDate = DateTime.Today,
                Question = question,
                User = user
            };

            //Act

            //Assert
        }

    }

}