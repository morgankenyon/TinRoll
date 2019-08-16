using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TinRoll.Logic.Manager;
using TinRoll.Shared;

namespace TinRoll.Server.Controllers
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
        public async Task<QuestionDto> GetQuestion(int Id)
        {
            var question = await _questionManager.GetQuestionAsync(Id);
            return question;
        }


        [HttpPost]
        public async Task<int> CreateQuestion(QuestionDto question)
        {
            var questionId = await _questionManager.CreateQuestionAsync(question);
            return questionId;
        }
    }
}