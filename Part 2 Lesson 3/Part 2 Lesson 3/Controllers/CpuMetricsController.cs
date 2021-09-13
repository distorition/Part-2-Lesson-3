using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        public CpuMetricsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "Встроили Nlog  в наш класс CpuMetricController");

        }
        [HttpGet("agentid/{agentID}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricCpy([FromRoute] int agentid, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime )
        {
            _logger.LogInformation("Наше Первое сообщение в лог");
            return Ok();
        }

    }
}
