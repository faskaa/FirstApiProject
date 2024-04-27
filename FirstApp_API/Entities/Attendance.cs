namespace FirstApp_API.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime  Date { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public bool IsHere { get; set; }
    }
}
