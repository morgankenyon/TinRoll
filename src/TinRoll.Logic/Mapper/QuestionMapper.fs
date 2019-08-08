module TinRoll.Logic.Mapper.QuestionMapper

open TinRoll.Data
open TinRoll.Shared

let ToDto (db: Question) =
    QuestionDto(Id =db.Id, Title = db.Title, Text = db.Text, UserId = db.UserId, CreatedDate = db.CreatedDate, UpdatedDate = db.UpdatedDate)

let ToDb (dto: QuestionDto) =
    Question(dto.Id, dto.Title, dto.Text, dto.UserId, dto.CreatedDate,dto.UpdatedDate)