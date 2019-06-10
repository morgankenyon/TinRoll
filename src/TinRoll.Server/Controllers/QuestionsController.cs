using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TinRoll.Data;
using TinRoll.Data.Entities;
using TinRoll.Shared;

namespace TinRoll.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private TinRollContext _context;
        public QuestionsController(TinRollContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            var dbQuestions = await _context.Questions.OrderByDescending(q => q.CreatedDate).ToListAsync();
            var dtoQuestions = dbQuestions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                Title = q.Title,
                CreatedDate = q.CreatedDate,
                UpdatedDate = q.UpdatedDate,
            });
            return dtoQuestions;
        }


        [HttpPost]
        public async Task<Question> CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }
    }
}