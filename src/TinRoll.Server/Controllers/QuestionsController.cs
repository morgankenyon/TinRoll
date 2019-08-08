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
        public IEnumerable<QuestionDto> GetQuestions()
        {
            var questions = _questionManager.GetQuestions();
            return questions;
        }

        [HttpGet("{Id}")]
        public QuestionDto GetQuestion(int Id)
        {
            var question = _questionManager.GetQuestion(Id);
            return question;
        }


        [HttpPost]
        public QuestionDto CreateQuestion(QuestionDto question)
        {
            var newQuestion = _questionManager.CreateQuestion(question);
            return newQuestion;
        }
    }
}