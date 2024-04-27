using FirstApp_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class AttendanceCreateDTO
    {
        [Required(ErrorMessage ="Fill the form")]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Fill the form")]
        public bool IsHere { get; set; }
    }
}
