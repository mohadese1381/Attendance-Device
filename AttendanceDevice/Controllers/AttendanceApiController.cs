using AttendanceDevice.Data;
using AttendanceDevice.Models;
using AttendanceDevice.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceDevice.Controllers
{
    [Route("api/Attendance")]
    [ApiController]
    public class AttendanceApiController : ControllerBase
    {

        private readonly IAttendanceService _service;
        public AttendanceApiController(IAttendanceService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (attendance.EntryTime < attendance.ExitTime)
            {
                return await _service.AddAsync(attendance) ?  Ok() :  BadRequest("No such a person to register attendance for");
            }
            return BadRequest("Entry time can't be earlier than Exit time ");    
        }
        [HttpGet]
        [Route("GetAllAttendances")]
        public async Task<IEnumerable<Attendance>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return result;
        }

        [HttpGet]
        [Route("GetByPersonId")]
        public async Task<IActionResult> GetByPersonId([FromQuery] int id)
        {
            var result = await _service.GetByPersonIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            await _service.DeleteByIdAsync(id);
            return Ok("Delete by id of Attendance done:)");
        }

        [HttpDelete]
        [Route("DeleteByPersonId")]
        public async Task<IActionResult> DeleteByPersonId([FromQuery] int id)
        {
            await _service.DeleteByPersonIdAsync(id);
            return Ok($"Delete all attendances of a person by id {id} :)");
        }

        [HttpPut]
        [Route("UpdateAttendance")]
        public async Task<IActionResult> UpdateAttendance([FromQuery] int id, [FromBody] Attendance newAttendance)
        {
            var result = await _service.UpdateAsync(id, newAttendance);
            return Ok($"Updated attendance is:\n{result.PersonId}\n{result.EntryTime}\n{result.ExitTime}");
        }

        [HttpPost]
        [Route("CreateAttendance/QrCode")]
        public async Task<IActionResult> CreateAttendance1(AttendanceViewModel attendanceViewModel)
        {
            var result = await _service.CreateByQrCodeAsync(attendanceViewModel);

            return result ? Ok("Register Done") : NotFound("No such a person!");
        }

        [HttpPost]
        [Route("CreateAttendance/IdentityCode")]
        public async Task<IActionResult> CreateAttendance2(AttendanceViewModel attendanceViewModel)
        {
            var result = await _service.CreateByICodeAsync(attendanceViewModel);

            return result ? Ok("Register Done") : NotFound("No such a person!");
        }
    }
}
