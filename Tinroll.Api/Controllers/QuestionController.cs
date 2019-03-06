using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tinroll.Business.Managers.Interfaces;
using Tinroll.Data.Entity;
using Tinroll.Model.Dto.Entity;

namespace Tinroll.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionManager _questionManager;
        public QuestionController(IQuestionManager questionManager) 
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionDto>> Get() 
        {
            return await _questionManager.GetAllQuestionsAsync();
        }

        // GET api/question/Guid
        [HttpGet("{id}")]
        public async Task<QuestionDto> Get(Guid id)
        {
            return await _questionManager.GetQuestionAsync(id);
        }

        // // POST api/question
        [HttpPost]
        public async Task Post(QuestionDto questionDto)
        {
            await _questionManager.CreateQuestionAsync(questionDto); //TODO: return an empty 201
        }

        // PUT api/question
        [HttpPut]
        public async Task Put(QuestionDto questionDto)
        {
            await _questionManager.UpdateQuestionAsync(questionDto); //TODO: return an empty 201
        }
    }
}
