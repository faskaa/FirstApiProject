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
    public class AttendanceController : ControllerBase
    {

        private readonly AcademyDBContext _context;
        private readonly IMapper _mapper;

        public AttendanceController(AcademyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            List<Member> members = _context.Members.Include(x => x.GroupMember).ThenInclude(x=>x.Group).Include(x=>x.Attendance).ToList();

            List<AttendanceGetAllDTO> dto = _mapper.Map<List<AttendanceGetAllDTO>>(members);

            return Ok(dto);
        }


        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {

            Member member = _context.Members.Include(x => x.GroupMember).ThenInclude(x => x.Group).Include(x => x.Attendance).FirstOrDefault(x => x.Id == id)!;
            AttendanceGetAllDTO dto = _mapper.Map<AttendanceGetAllDTO>(member);
            return Ok(dto);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromForm]AttendanceCreateDTO attendance)
        {
            Attendance newAttendance = new Attendance
            {
                MemberId = attendance.MemberId,
                Date = DateTime.Now,
                IsHere = attendance.IsHere,
            };

            _context.Attendance.Add(newAttendance);
            _context.SaveChanges();
            return Ok(attendance);
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IActionResult Update(int id ,[FromForm]AttendanceUpdateDTO attendance)
        {
            Attendance oldAttendance = _context.Attendance.FirstOrDefault(x => x.Id == id)!;
            if (oldAttendance == null) return NotFound();

            oldAttendance.IsHere = attendance.IsHere;
            _context.SaveChanges();


            return Ok(attendance);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Attendance attendance = _context.Attendance.FirstOrDefault(x => x.Id == id)!;
            if (attendance == null) return NotFound();
            _context.Attendance.Remove(attendance);
            _context.SaveChanges();


            return Ok(attendance);
        }

        [HttpGet]
        [Route("GetAttendance/{id}")]
        public IActionResult GetAttendance(int id)
        {

            Member member = _context.Members.Include(x => x.GroupMember).ThenInclude(x => x.Group).Include(x => x.Attendance).FirstOrDefault(x => x.Id == id)!;
            if(member is null) return NotFound();
            double isHere = 0;
            double total = 0;
            foreach (var item in member.Attendance)
            {
                total ++;
                if (item.IsHere == true) isHere++;
            }
            double percentCalc = (double)isHere * 100/total;
            AttendanceGetAllDTO dto = _mapper.Map<AttendanceGetAllDTO>(member);
            
            return Ok(percentCalc+"%");
        }
    }
}
