using Tinroll.Data.Entities;
using Tinroll.Model.User;

namespace Tinroll.Business.Mapping
{
    public class UserMapping
    {
        public static UserDto ToDto(User user) => new UserDto()
        {
            UserId = user.UserId,
            UserName = user.UserName
        };

        public static User ToEntity(UserDto userDto) => new User()
        {
            UserId = userDto.UserId,
            UserName = userDto.UserName
        };
    }
}