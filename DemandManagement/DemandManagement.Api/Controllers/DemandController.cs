﻿using DemandManagement.Api.Model;
using DemandManagement.MessageContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemandManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterDemandModel demand)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.RegisterDemandServiceQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IRegisterDemandCommand>(new
            {
                Subject = demand.Subject,
                Description = demand.Description
            });

            return Ok("Thanks");
        }
    }
}
