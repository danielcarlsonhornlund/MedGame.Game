namespace MedGame.Dots.Authentication
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }

        public bool IsForbidden { get; set; }

        public string Token { get; set; }
    }
}
