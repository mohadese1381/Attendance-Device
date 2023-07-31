using AttendanceDevice.Models;
using AttendanceDevice.View_Model;
using Microsoft.EntityFrameworkCore;

namespace AttendanceDevice.Data
{
    public class AttendanceService :IAttendanceService
    {
        readonly AppDbContext _context;
        readonly IPersonService _personService;
        public AttendanceService(AppDbContext context,IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        public async Task<bool> AddAsync(Attendance attendance)
        {
            if(!(_context.Person.Where(p => p.PersonId == attendance.PersonId).Any()))
            {
                return false;
            }
            await _context.Attendance.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AddAsync(AttendanceViewModel attendanceViewModel)
        {
            Attendance attendance = new Attendance();
            attendance.EntryTime = attendanceViewModel.EntryTime;
            attendance.ExitTime = attendanceViewModel.ExitTime;
            attendance.PersonId = attendanceViewModel.PersonId;
            await _context.Attendance.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var result = await _context.Attendance.FirstOrDefaultAsync(a => a.AttendanceId == id);
            if (result != null)
                _context.Attendance.Remove(result);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteByPersonIdAsync(int id)
        {
            var result = await _context.Attendance.Where(x => x.PersonId == id).ToListAsync();
            if (result != null)
            {
                foreach(var attendance in result)
                    _context.Attendance.Remove(attendance);
            }
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>>GetAllAsync()
        {
           var result = await _context.Attendance.ToListAsync();
           return result;
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            var result = await _context.Attendance.FirstOrDefaultAsync(a => a.AttendanceId == id);
            return result;   
        }

        public async Task<IEnumerable<Attendance>> GetByPersonIdAsync(int id)
        {
            var result = await _context.Attendance.Where(x => x.PersonId == id).ToListAsync();
            return result;
        }

        public async Task<Attendance> UpdateAsync(int id, Attendance newAttendance)
        {
            newAttendance.AttendanceId = id;
            newAttendance.PersonId = _context.Attendance.Where(a => a.AttendanceId == id).FirstOrDefault().PersonId;
            _context.Attendance.Attach(newAttendance);
            await _context.SaveChangesAsync();
            return newAttendance;
        }

        public async Task<bool> CreateByQrCodeAsync(AttendanceViewModel attendanceViewModel)
        {
            var person = await _personService.GetByQrCodePic((Convert.FromBase64String(attendanceViewModel.QrCodeStr)));

           if(person != null)
            {
                attendanceViewModel.PersonId = person.PersonId;
                await AddAsync(attendanceViewModel);
                return true;
            }
           return false;
        }

        public async Task<bool> CreateByICodeAsync(AttendanceViewModel attendanceViewModel)
        {
            var person = await _personService.GetByIdentityCode(attendanceViewModel.identityCode);
            if (person!=null)
            {
                attendanceViewModel.PersonId = person.PersonId;
                await AddAsync(attendanceViewModel);
                return true;
            }
            return false;
                

        }
    }
}
