using System.ComponentModel.DataAnnotations;

namespace BlazorWebAss.Models
{
    public class AddUserFormModel
    {
        [Required(ErrorMessage = "FirstName is required field")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "LastName is required field")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "FatherName is required field")]
        public string FatherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Login is required field")]
        public string Login { get; set; } = string.Empty;
    }
}
