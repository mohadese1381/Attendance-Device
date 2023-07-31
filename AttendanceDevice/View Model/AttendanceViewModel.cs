namespace AttendanceDevice.View_Model
{
    public class AttendanceViewModel
    {
        public int PersonId { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string QrCodeStr { get; set; }
        public int identityCode { get; set; }
    }
}
