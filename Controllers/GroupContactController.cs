using InfoTextSMSDashboard.BLL.Interfaces;
using InfoTextSMSDashboard.DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTextSMSDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupContactController : ControllerBase
    {
        private readonly IGroupContactService _service;

        public GroupContactController(IGroupContactService service)
        {
            _service = service;
        }

        [HttpPost("AddContactToGroup")]
        public async Task<IActionResult> AddContact([FromBody] GroupContactListDTO groupContacts)
        {
            var contactsNotAdded = 0;
            var errorMessages = new List<string>();

            var succesMessages = new List<string>();

            var contactsAdded = 0;

            foreach ( var contactId in groupContacts.ContactIds)
            {
                var groupContact = new GroupContactDTO
                {
                    GroupId = groupContacts.GroupId,
                    ContactId = contactId
                };



                var outputResponse = await _service.AddContactToGroup(groupContact);

                if (!outputResponse.IsSuccess)
                {
                    contactsNotAdded++;
                    //return BadRequest(outputResponse.Message);
                }
                else
                {
              contactsAdded++;
                }
                //return Ok(outputResponse.Message);
            }

            string finalReturnMessage = $"error count:{contactsNotAdded}, messages: {errorMessages}, " +
                $"success count: {contactsAdded},  + messages: {succesMessages}";

            return Ok(finalReturnMessage);
        }

        [HttpGet("GetContactInGroupId")]
        public async Task<IActionResult> GetContactsInGroup([FromQuery] int id)
        {
            var outputResponse = await _service.GetContactsInGroup(id);

            if (!outputResponse.IsSuccess)
            {

                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.SuccessResult);

        }

        [HttpDelete("DeleteContactInGroup")]
        public async Task<IActionResult> DeleteContractInGroup(int contactId, int groupId)
        {
            var groupContact = new GroupContactDTO()
            {
                ContactId = contactId,
                GroupId = groupId
            };

            var outputResponse = await _service.RemoveContactInGroup(groupContact);
        

            if (!outputResponse.IsSuccess)
            {
                return BadRequest(outputResponse.Message);
            }

            return Ok(outputResponse.Message);

        }

    }
}
