using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TinRoll.Data;
using TinRoll.Data.Entities;

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
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
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