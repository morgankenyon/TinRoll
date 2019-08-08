module TinRoll.Logic.Mapper.UserMapper

open TinRoll.Data
open TinRoll.Shared
open System.Collections

let ToDto (db: User) =
    UserDto(Id= db.Id, Email = db.Email, Username = db.Username, CreatedDate = db.CreatedDate, UpdatedDate = db.UpdatedDate)

let ToDb (dto: UserDto) =
    User(dto.Id, dto.Email, dto.Username, new Generic.List<Question>(), dto.CreatedDate, dto.CreatedDate)

