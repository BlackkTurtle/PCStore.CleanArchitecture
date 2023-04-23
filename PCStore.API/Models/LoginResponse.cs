namespace PCStore.API.Models
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
