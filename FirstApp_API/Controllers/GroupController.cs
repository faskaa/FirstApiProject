using AutoMapper;
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

    public class GroupController : ControllerBase
    {
        private readonly AcademyDBContext _context;
        private readonly IMapper _mapper;

        public GroupController(AcademyDBContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Group> groups = _context.Groups.ToList();

            GroupGetAllDTO dto = _mapper.Map<GroupGetAllDTO>(groups);

            return Ok(dto);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Group group = _context.Groups.FirstOrDefault(g => g.Id == id)!;
            if (group == null) return NotFound();

            GroupGetDTO dto = _mapper.Map<GroupGetDTO>(group);

            return Ok(dto);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(GroupCreateDTO Group)
        {
            Group newGroup = new Group
            {
                Name = Group.Name,
                Profession = Group.Profession,
                CreatedAt = DateTime.Now,
                
            };

            _context.Groups.Add(newGroup);
            _context.SaveChanges();

            return Ok(newGroup);

        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(int id ,[FromBody]GroupUpdateDTO group)
        {
            Group existed = _context.Groups.FirstOrDefault(x => x.Id == id)! ?? throw new NullReferenceException("Group is not found");
            if (group.Name is not null )
            {
               existed.Name = group.Name;
            }

            if (group.Profession is not null)
            {
               existed.Profession = group.Profession;
            }
            
            existed.ModifiedAt = DateTime.Now;
            _context.SaveChanges();

            return Ok(group);
        }


        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
           Group group = _context.Groups.FirstOrDefault(x=>x.Id == id)! ?? throw new NullReferenceException("Group is not found");

            _context.Groups.Remove(group);
            _context.SaveChanges();

            return Ok(group);
        }
    }
}
