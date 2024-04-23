using FirstApp_API.DAL;
using FirstApp_API.DTOs;
using FirstApp_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly AcademyDBContext _context;

        public MemberController(AcademyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Member> members =_context.Members.Include(x=>x.GroupMember).ToList();
            return Ok(new
            {
                StatusCode = 200,
                Data = members
            } );
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            Member members = _context.Members.Include(x => x.GroupMember).FirstOrDefault(x=>x.Id == id)!;
            if (members == null) return NotFound();
            return Ok(new
            {
                StatusCode = 200,
                Data = members
            });
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
            return Ok();
        }

        [HttpPost]
        [Route("AddToGroup")]
        public IActionResult AddToGroup([FromForm]int groupId ,[FromForm]int memberId)
        {
            if (!ModelState.IsValid) return BadRequest();
            Member member = _context.Members.FirstOrDefault(x => x.Id == memberId)!;
            if (member == null) return NotFound();

            Group group = _context.Groups.FirstOrDefault(x => x.Id == groupId)!;
            if (group == null) return NotFound();


            bool memberExistedInGroup = _context.GroupMembers.Any(x => x.GroupId == groupId && x.MemberId == memberId);
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
                GroupId = groupId,
                MemberId = memberId
            };

            _context.GroupMembers.Add(groupMember);
            _context.SaveChanges();
            return Ok();
        }


    }
}
