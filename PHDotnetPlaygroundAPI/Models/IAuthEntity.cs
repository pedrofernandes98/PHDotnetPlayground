namespace PHDotnetPlaygroundAPI.Models
{
    public interface IAuthEntity
    {
        public string User { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }
    }
}