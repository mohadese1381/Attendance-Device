using AttendanceDevice.Models;

namespace AttendanceDevice.Data
{
    public interface IPersonService
    {
        public Task<IEnumerable<Person>> GetAllAsync();
        public Task<Person> GetByIdAsync(int id);
        public Task<Person> GetByIdentityCode(int IdentityCode);
        public Task<Person> GetByQrCodePic(byte[] qrCodePic);
        public Task<Person> UpdateAsync(int id, Person newPerson);
        public Task DeleteAsync(int id);
        public Task AddAsync(Person person);
       
    }
}