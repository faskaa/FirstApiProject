using FirstApp_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class MemberUpdateDTO
    {
        //[Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters")]
        [Display(Name = "Member's name")]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters")]
        [Display(Name = "Member's surname")]
        public string? Surname { get; set; }

        //[Required(ErrorMessage = "Fill the field")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Role must contain only letters")]
        [Display(Name = "Member's role")]
        public string? Role { get; set; }

    }
}
