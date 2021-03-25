using AuthJWT.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]
    public class PatientDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHubContext<PatientDataHub> _hub;
        public PatientDataController(IHubContext<PatientDataHub> hub, IConfiguration configuration)
        {
            _configuration = configuration;
            _hub = hub;
        }

        [HttpPost]
        public IActionResult Temperature([FromBody] TemperatureDTO data)
        {
            _hub.Clients.All.SendAsync("transferTemperature", data.Temperature);
            return  Ok(new { Message = "Request Completed" });
        }
    }
}

public class TemperatureDTO
{
    public float Temperature { get; set; }
}