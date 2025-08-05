using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberRiskTracker.Data.Entities
{
    public class RiskItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ImageUrl { get; set; } = string.Empty;

        [MaxLength(100)]
        public string HowItWorks { get; set; } = string.Empty;

        [MaxLength(100)]
        public string AdditionalInformation { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ImageName { get; set; } = string.Empty;

        public byte[]? ImageContent { get; set; }

        [NotMapped]
        public string ImageFullPath => $"/images/{ImageUrl}";
    }

}
