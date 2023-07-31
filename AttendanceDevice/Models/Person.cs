using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QRCoder;

namespace AttendanceDevice.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Name needed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName needed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "National code needed")]
        public string NationalCode { get; set; }
        public string? PictureURL { get; set; }
        public int? IdentityCode { get; set; }
        public byte[]? QrCodeData { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
