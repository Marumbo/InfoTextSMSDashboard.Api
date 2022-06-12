using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTextSMSDashboard.BLL.Models;
using InfoTextSMSDashboard.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoTextSMSDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsService _service;
        public SMSController(ISmsService smsService)
        {
            _service = smsService;
        }

        [HttpPost("sendSMS")]
        public async Task<IActionResult> SendSMS([FromBody]SMS sms)
        {
            var outputresponse = await _service.SendSMS(sms);

            if (!outputresponse.IsSuccess)
            {
                return BadRequest(outputresponse.Message);
            }

            return Ok(outputresponse.Message);

        }

        [HttpGet("GetMessageById")]
        public async Task<IActionResult> GetMessageById([FromQuery]int Id)
        {
            var outputresponse = await _service.GetMessageById(Id);

            if (!outputresponse.IsSuccess)
            {
                return BadRequest(outputresponse.Message);
            }

            return Ok(outputresponse.Message);
        }

        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessages()
        {
            var outputResponse = await _service.GetMessages();
            
            if(!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);
            
        }
       
    }
}