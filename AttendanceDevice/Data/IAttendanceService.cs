using AttendanceDevice.Models;
using AttendanceDevice.View_Model;

namespace AttendanceDevice.Data
{
    public interface IAttendanceService
    {
        public Task<IEnumerable<Attendance>> GetAllAsync();
        public Task<IEnumerable<Attendance>> GetByPersonIdAsync(int id);//id of person
        public Task<Attendance> GetByIdAsync(int id);//id of Attendance
        public Task<Attendance> UpdateAsync(int id, Attendance newAttendance);
        public Task DeleteByPersonIdAsync(int id);//id of person
        public Task DeleteByIdAsync(int id);//id of Attendance
        public Task<bool> AddAsync(Attendance attendance);
        public Task<bool> CreateByQrCodeAsync(AttendanceViewModel attendanceViewModel);
        public Task<bool> CreateByICodeAsync(AttendanceViewModel attendanceViewModel);
    }
}
