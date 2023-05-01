using System.ComponentModel.DataAnnotations;

namespace BlazorWebAss.Models
{
    public class DeleteUserFormModel
    {
        [Required(ErrorMessage = "Login is required field")]
        public string Login { get; set; } = string.Empty;
    }
}
