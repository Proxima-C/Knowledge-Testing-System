using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAnswerController : ControllerBase
    {
        private readonly ITestAnswerService _testAnswerService;

        public TestAnswerController(ITestAnswerService testAnswerService)
        {
            _testAnswerService = testAnswerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TestAnswerDTO> answers = await _testAnswerService.GetAll();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestAnswerDTO>> GetById(int id)
        {
            TestAnswerDTO answer = await _testAnswerService.GetByIdAsync(id);
            return new ObjectResult(answer);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TestAnswerDTO answer)
        {
            await _testAnswerService.AddAsync(answer);
            return Ok(answer);
        }

        [HttpPut]
        public async Task<ActionResult> Update(TestAnswerDTO answer)
        {
            await _testAnswerService.UpdateAsync(answer);
            return Ok(answer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _testAnswerService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
