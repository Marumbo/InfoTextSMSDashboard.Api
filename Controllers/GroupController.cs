using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTextSMSDashboard.BLL.Interfaces;
using InfoTextSMSDashboard.DataModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoTextSMSDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        public GroupController(IGroupService service)
        {
            _service = service;
        }

        [HttpGet("GetAllGroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var outputResponse = await _service.GetAllGroups();

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);

        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroup([FromBody]GroupsDTO group)
        {
            var outputResponse = await _service.AddGroup(group);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);
        }

        [HttpGet("GetGroupById")]
        public async Task<IActionResult> GetGroupById([FromQuery]int id)
        {
            var outputResponse = await _service.GetGroupById(id);

            if (!outputResponse.IsSuccess)
            {

                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);

        }

        [HttpPut("UpdateGroup")]
        public async Task<IActionResult> UpdateGroup([FromBody]GroupsDTO group)
        {
            var outputResponse = await _service.UpdateGroup(group);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);
        }

        [HttpDelete("DeleteGroup")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var outputResponse = await _service.RemoveGroup(id);

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);

        }


    }
}