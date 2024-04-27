using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class GroupCreateDTO
    {
        [Required(ErrorMessage = "Fill the field")]
        [Display(Name = "Group's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill the field")]
        [Display(Name = "Group's profession")]
        public string Profession { get; set; }
    }
}
