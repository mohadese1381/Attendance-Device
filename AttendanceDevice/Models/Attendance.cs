using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceDevice.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public DayOfWeek Day { get; set; }
        [Required(ErrorMessage ="Entry time needed")]
        public DateTime EntryTime { get; set; }
        [Required(ErrorMessage = "Exit time needed")]
        public DateTime ExitTime { get; set; }
    }
}
