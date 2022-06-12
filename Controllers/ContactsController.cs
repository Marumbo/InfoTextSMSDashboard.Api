using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTextSMSDashboard.BLL.Interfaces;
using InfoTextSMSDashboard.BLL.Models;
using InfoTextSMSDashboard.DataModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTextSMSDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _service;
        public ContactsController(IContactsService service)
        {
            _service = service;
        }

        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var outputResponse = await _service.GetContacts();

            if (outputResponse.IsSuccess == false)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);

        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact([FromBody]ContactsDTO contact)
        {
            var outputResponse = await _service.AddContact(contact);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetContactById([FromQuery]int id)
        {
            var outputResponse = await _service.GetContactById(id);

            if (!outputResponse.IsSuccess)
            {

                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);

        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact([FromBody]ContactsDTO contact)
        {
            var outputResponse = await _service.UpdateContact(contact);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContact([FromQuery]int id)
        {
            var outputResponse = await _service.DeleteContact(id);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);

        }


    }
}