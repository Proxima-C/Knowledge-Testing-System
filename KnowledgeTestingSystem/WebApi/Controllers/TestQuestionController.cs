using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionController : ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;

        public TestQuestionController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestQuestionDTO>>> GetAll()
        {
            IEnumerable<TestQuestionDTO> questions = await _testQuestionService.GetAllAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestQuestionDTO>> GetById(int id)
        {
            TestQuestionDTO question = await _testQuestionService.GetByIdAsync(id);
            return new ObjectResult(question);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<ActionResult<TestQuestionDTO>> Add([FromBody] TestQuestionDTO question)
        {
            await _testQuestionService.AddAsync(question);
            return Ok(question);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut]
        public async Task<ActionResult<TestQuestionDTO>> Update(TestQuestionDTO question)
        {
            await _testQuestionService.UpdateAsync(question);
            return Ok(question);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _testQuestionService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
