﻿using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStatisticsController : ControllerBase
    {
        private readonly ITestStatisticsService _testStatisticsService;

        public TestStatisticsController(ITestStatisticsService testStatisticsService)
        {
            _testStatisticsService = testStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TestStatisticsDTO> statistics = await _testStatisticsService.GetAll();
            return Ok(statistics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestStatisticsDTO>> GetById(int id)
        {
            TestStatisticsDTO statistics = await _testStatisticsService.GetByIdAsync(id);
            return new ObjectResult(statistics);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TestStatisticsDTO statistics)
        {
            await _testStatisticsService.AddAsync(statistics);
            return Ok(statistics);
        }

        [HttpPut]
        public async Task<ActionResult> Update(TestStatisticsDTO statistics)
        {
            await _testStatisticsService.UpdateAsync(statistics);
            return Ok(statistics);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _testStatisticsService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}