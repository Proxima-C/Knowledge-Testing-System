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
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDTO>>> GetAll()
        {
            IEnumerable<TestDTO> tests = await _testService.GetAllAsync();
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestDTO>> GetById(int id)
        {
            TestDTO test = await _testService.GetByIdAsync(id);
            return new ObjectResult(test);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost]
        public async Task<ActionResult<TestDTO>> Add([FromBody] TestDTO test)
        {
            await _testService.AddAsync(test);
            return Ok(test);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut]
        public async Task<ActionResult<TestDTO>> Update([FromBody] TestDTO test)
        {
            await _testService.UpdateAsync(test);
            return Ok(test);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _testService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
