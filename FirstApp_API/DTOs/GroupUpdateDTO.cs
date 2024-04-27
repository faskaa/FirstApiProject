using System.ComponentModel.DataAnnotations;

namespace FirstApp_API.DTOs
{
    public class GroupUpdateDTO
    {

        [Display(Name = "Group's name")]
        public string? Name { get; set; }

        [Display(Name = "Group's profession")]
        public string? Profession { get; set; }
    }
}
