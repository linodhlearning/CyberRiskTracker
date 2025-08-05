using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CyberRiskTracker.Models.Enums;
namespace CyberRiskTracker.Data.Entities
{ 

public class AssetEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Owner { get; set; } = string.Empty;

        public EnvironmentType Environment { get; set; } = EnvironmentType.Development;

        public RiskLevel RiskLevel { get; set; } = RiskLevel.Low;

        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;
    }

}
