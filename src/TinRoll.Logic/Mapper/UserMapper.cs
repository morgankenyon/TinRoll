using TinRoll.Data;
using TinRoll.Shared;

namespace TinRoll.Logic.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.Username,
                Questions = user.Questions,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }
        public static User ToDb(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Username = userDto.UserName,
                CreatedDate = userDto.CreatedDate,
                UpdatedDate = userDto.UpdatedDate
            };
        }
    }
}
