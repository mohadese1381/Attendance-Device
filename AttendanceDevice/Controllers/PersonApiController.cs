using AttendanceDevice.Data;
using AttendanceDevice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceDevice.Controllers
{
    [Route("api/PersonController")]
    [ApiController]
    public class PersonApiController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonApiController(IPersonService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody]Person person)
        {
            await _service.AddAsync(person);
            return Ok("User created :)");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            await _service.DeleteAsync(id);
            return Ok("User deleted:)");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePerson([FromQuery] int id,[FromBody]Person newPerson)
        {
           var result = await _service.UpdateAsync(id,newPerson);
            return Ok(result);
        }
      
    }
}
