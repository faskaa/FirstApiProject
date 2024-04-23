using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class MemberCreateDTO
    {
        [Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Role must contain only letters")]
        public string Role { get; set; }

    }
}
