using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberRiskTracker.Data.Entities
{

    public class LoginAttemptEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        public DateTime AttemptTime { get; set; }

        [MaxLength(50)]
        public string IPAddress { get; set; } = string.Empty;

        public bool IsSuccessful { get; set; }

        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Method { get; set; } = string.Empty;
    }

}
