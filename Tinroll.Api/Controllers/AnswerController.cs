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
    public class AnswerController : ControllerBase
    {
        private IAnswerManager _answerManager;
        public AnswerController(IAnswerManager answerManager) 
        {
            _answerManager = answerManager;
        }

        [HttpGet]
        public async Task<IEnumerable<AnswerDto>> Get() 
        {
            return await _answerManager.GetAllAnswersAsync();
        }

        // GET api/answer/Guid
        [HttpGet("{id}")]
        public async Task<AnswerDto> Get(Guid id)
        {
            return await _answerManager.GetAnswerAsync(id);
        }

        // POST api/answer
        [HttpPost]
        public async Task Post(AnswerDto answerDto)
        {
            await _answerManager.CreateAnswerAsync(answerDto); //TODO: return an empty 201
        }

        // PUT api/answer
        [HttpPut]
        public async Task Put(AnswerDto answerDto)
        {
            await _answerManager.UpdateAnswerAsync(answerDto); //TODO: return an empty 201
        }
    }
}
