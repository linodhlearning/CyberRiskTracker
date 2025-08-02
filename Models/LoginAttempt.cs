namespace CyberRiskTracker.Models
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public DateTime AttemptTime { get; set; }
        public string IPAddress { get; set; } = "";
        public bool IsSuccessful { get; set; }
        public string Location { get; set; } = "";
        public string Method { get; set; } = ""; // Web, API, Mobile, etc.
    }

}
