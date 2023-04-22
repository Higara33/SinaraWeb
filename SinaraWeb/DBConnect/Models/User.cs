namespace SinaraWeb.DBConnect.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FatherName { get; set; }
        public ActiveDirectory Login { get; set; }
    }
}
