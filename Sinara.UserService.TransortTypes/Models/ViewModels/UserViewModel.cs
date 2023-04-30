namespace Sinara.UserService.TransortTypes.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Login { get; set; }
        public bool Deleted { get; set; }
    }
}
