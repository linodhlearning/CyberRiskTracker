namespace CyberRiskTracker.Models
{
    public class RiskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public string ImageFullPath { get { return $"/images/{ImageUrl}"; }  }
    }
}
