using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using TinRoll.Data.Entities;
using TinRoll.Logic.Mappers;
using TinRoll.Shared.Dtos;
using Xunit;

namespace TinRoll.Test.Logic.MapperTests
{
    public class UserMapperTests
    {
        [Fact]
        public void Test_User_To_UserDto()
        {
            //arrange
            var user = new User
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                Email = "testEmail1",
                UpdatedDate = DateTime.UtcNow,
                Username = "testUsername"
            };

            //act
            var userDto = UserMapper.ToDto(user);

            //assert
            userDto.Should().NotBeNull();
            userDto.Id.Should().Be(user.Id);
            userDto.CreatedDate.Should().Be(user.CreatedDate);
            userDto.Email.Should().Be(user.Email);
            userDto.UpdatedDate.Should().Be(user.UpdatedDate);
            userDto.Username.Should().Be(user.Username);
        }

        [Fact]
        public void Test_UserDto_To_User()
        {
            //arrange
            var userDto = new UserDto
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                Email = "testEmail1",
                UpdatedDate = DateTime.UtcNow,
                Username = "testUsername"
            };

            //act
            var user = UserMapper.ToDb(userDto);

            user.Should().NotBeNull();
            user.Id.Should().Be(userDto.Id);
            user.CreatedDate.Should().Be(userDto.CreatedDate);
            user.Email.Should().Be(userDto.Email);
            user.UpdatedDate.Should().Be(userDto.UpdatedDate);
            user.Username.Should().Be(userDto.Username);

            user.QuestionTags.Should().BeNull();
            user.Questions.Should().BeNull();
            user.Answers.Should().BeNull();
            user.Tags.Should().BeNull();
        }
    }
}
