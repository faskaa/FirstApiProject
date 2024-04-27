using AutoMapper;
using FirstApp_API.DTOs;
using FirstApp_API.Entities;

namespace FirstApp_API.Mapper
{
    public class AutoMapperConfigruation:Profile
    {
        public AutoMapperConfigruation()
        {
            CreateMap<Group , GroupGetDTO>();
            CreateMap<Group , GroupGetAllDTO>();
            CreateMap<Member , MemberGetDTO>();
            CreateMap<Member , MemberGetAllDTO>();
            CreateMap<GroupMember, GroupMemberDTO>().ForMember(gmd => gmd.GroupName, gm => gm.MapFrom(g => g.Group != null ? g.Group.Name : "Not a member of any group"));
            CreateMap<Member, AttendanceGetAllDTO>();
            CreateMap<Attendance, AttendanceDTO>().ForMember(d => d.Date, opt => opt.MapFrom(t => t.Date.ToString("dd MMMM yyyy")));



        }
    }
}
