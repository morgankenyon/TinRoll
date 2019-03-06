using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Business.Mapping
{
    public class UserMapper
    {
        public static UserDto ToDto(User user) => new UserDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            Description = user.Description
        };

        public static User ToEntity(UserDto userDto) => new User()
        {
            UserId = userDto.UserId,
            UserName = userDto.UserName,
            Email = userDto.Email,
            Description = userDto.Description
        };
    }
}