namespace BlazorWebAss.Models
{
    public class Response
    {
        public ErrorResult[] Errors { get; set; }
        public User[] Data { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Login { get; set; }
        public bool Deleted { get; set; }
    }

    public class ErrorResult
    {
        public ErrorResult()
        {

        }

        public ErrorResult(string key, string msg)
        {
            ErrorKey = key;
            ErrorMessage = msg;
        }

        public string ErrorKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}
