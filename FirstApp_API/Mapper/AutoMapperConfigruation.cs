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
            CreateMap<GroupMember, GroupMemberDTO>().ForMember(gmd => gmd.GroupName, gm => gm.MapFrom(g => g.Group.Name));


        }
    }
}
