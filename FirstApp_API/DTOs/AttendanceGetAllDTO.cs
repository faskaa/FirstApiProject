using FirstApp_API.Entities;

namespace FirstApp_API.DTOs
{
    public class AttendanceGetAllDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        public List<GroupMemberDTO> GroupMember { get; set; }
        public List<AttendanceDTO> Attendance { get; set; }

    }
}
