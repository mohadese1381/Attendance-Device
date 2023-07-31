using AttendanceDevice.Models;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace AttendanceDevice.Data
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        public PersonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Person person)
        {
            int tempId;
            //To export QRCODE and IDENTITY CODE for a person
            using var qrGenerator = new QRCodeGenerator();
            person.QrCodeData = qrGenerator.CreateQrCode(person.NationalCode, QRCodeGenerator.ECCLevel.Q).GetRawData(QRCodeData.Compression.GZip);
            tempId = _context.Person.OrderBy(ic => ic.PersonId).Select(ic => ic.PersonId).LastOrDefault();
            person.IdentityCode = tempId++;
            //------------Done
            await  _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
                 _context.Person.Remove(result);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var result = await _context.Person.ToListAsync();
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<Person> GetByIdAsync(int id)
        {
            var result = await _context.Person.FirstOrDefaultAsync(p => p.PersonId == id);
            return result;
        }
        public async Task<Person> UpdateAsync(int id, Person newPerson)
        {
            newPerson.PersonId = id;
            _context.Person.Update(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }
        public async Task<Person> GetByIdentityCode(int IdentityCode)
        {
            var result = await _context.Person.FirstOrDefaultAsync(p => p.IdentityCode == IdentityCode);

            return result;
        }

        public async Task<Person> GetByQrCodePic(byte[] qrCodePic)
        {
            var result = await _context.Person.FirstOrDefaultAsync(p => p.QrCodeData == qrCodePic);

            return result;
        }
    }
}
