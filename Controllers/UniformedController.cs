using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProjectSignalR.Model;
using ProjectSignalR.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSignalR.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("any")]
    public class UniformedController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public UniformedController(IHubContext<ChatHub> hubContext) {
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> SendAllInfo(UniformedServiceResponse response)
        {
            string json = JsonConvert.SerializeObject(response);
            if (response!=null)
            {
               await _hubContext.Clients.All.SendAsync("UniformedUpdate", json);
            }
            return Ok(); 
        }
    }
}
