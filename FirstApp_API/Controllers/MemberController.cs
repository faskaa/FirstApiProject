using AutoMapper;
using FirstApp_API.DAL;
using FirstApp_API.DTOs;
using FirstApp_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design.Serialization;

namespace FirstApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly AcademyDBContext _context;
        private readonly IMapper _mapper;

        public MemberController(AcademyDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Member> members =_context.Members.Include(x=>x.GroupMember).ThenInclude(x=>x.Group).ToList();

            List<MemberGetAllDTO> dto = _mapper.Map<List<MemberGetAllDTO>>(members);

            return Ok(dto); 
     
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            Member members = _context.Members.Include(x => x.GroupMember).ThenInclude(g=>g.Group).FirstOrDefault(x=>x.Id == id)!;
            if (members == null) return NotFound();

            MemberGetDTO dto = _mapper.Map<MemberGetDTO>(members);
            return Ok(dto);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]MemberCreateDTO member)
        {
            if (!ModelState.IsValid) return BadRequest();

            Member newMember = new Member
            {
                Name = member.Name,
                Surname = member.Surname,
                Role = member.Role,
                
            };

            _context.Members.Add(newMember);
            _context.SaveChanges();
            return Ok(newMember);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IActionResult Update(int id ,[FromForm]MemberUpdateDTO updatedMember)
        {
            if (!ModelState.IsValid) return BadRequest();
            Member member = _context.Members.Include(x=>x.GroupMember).ThenInclude(x=>x.Group).FirstOrDefault(x => x.Id == id)!;
            if (member is null) return NotFound();

            if (!string.IsNullOrEmpty(updatedMember.Name))
            {
                member.Name = updatedMember.Name;
            }

            if (!string.IsNullOrEmpty(updatedMember.Surname))
            {
               member.Surname = updatedMember.Surname;
            }

            if (!string.IsNullOrEmpty(updatedMember.Role))
            {
               member.Role = updatedMember.Role;
            }

    

            _context.SaveChanges();
           
            return Ok();
        }

        [HttpPost]
        [Route("AddToGroup")]
        public IActionResult AddToGroup([FromForm]MemberAddToGroupDTO memberDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Member member = _context.Members.FirstOrDefault(x => x.Id == memberDto.MemberId)!;
            if (member == null) return NotFound();

            Group group = _context.Groups.FirstOrDefault(x => x.Id == memberDto.GroupId)!;
            if (group == null) return NotFound();


            bool memberExistedInGroup = _context.GroupMembers.Any(x => x.GroupId == memberDto.GroupId && x.MemberId == memberDto.MemberId);
            if (memberExistedInGroup) return BadRequest(new { Error = "Selected member already exists in the group" });
            //List<GroupMember> allMembers = _context.GroupMembers.Where(x=>x.GroupId == groupId).ToList();
            //foreach (var item in allMembers)
            //{
            //    if (item.MemberId == memberId)
            //    {
            //        return BadRequest(new
            //        {
            //            Error = "Selected member already exists in the group"
            //        });
            //    }
            //}

            GroupMember groupMember = new GroupMember
            {
                GroupId = memberDto.GroupId,
                MemberId = memberDto.MemberId
            };

            _context.GroupMembers.Add(groupMember);
            _context.SaveChanges();
            return Ok(groupMember);
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Member member = _context.Members.FirstOrDefault(x => x.Id == id)!;
            if (member == null) return NotFound();
            _context.Members.Remove(member);
            _context.SaveChanges();


            return Ok(member);
        }


    }
}
