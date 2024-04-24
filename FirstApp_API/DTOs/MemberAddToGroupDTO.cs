using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class MemberAddToGroupDTO
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int MemberId { get; set; }
    }
}
