using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TinRoll.Api.ApiErrors;
using TinRoll.Logic.Managers.Interfaces;
using TinRoll.Shared.Dtos;

namespace TinRoll.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;

        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            var questions = await _questionManager.GetQuestionsAsync();
            return questions;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetQuestion(int Id)
        {
            var question = await _questionManager.GetQuestionAsync(Id);

            if (question == null)
            {
                return NotFound(new NotFoundError("The question was not found"));
            }

            return Ok(question);
        }


        [HttpPost]
        public async Task<QuestionDto> CreateQuestion(CreateQuestionDto question)
        {
            var newQuestion = await _questionManager.CreateQuestionAsync(question);
            return newQuestion;
        }
    }
}
