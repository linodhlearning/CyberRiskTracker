using static CyberRiskTracker.Models.Enums;

namespace CyberRiskTracker.Models
{ 
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public EnvironmentType Environment { get; set; } = EnvironmentType.Development;
        public RiskLevel RiskLevel { get; set; } = RiskLevel.Low;
        public string Location { get; set; } = string.Empty;
    }

}
