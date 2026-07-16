using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NooshApp.Models
{
    /// <summary>
    /// One row per points-earning event for a user.
    /// This is our audit trail — never overwrite points, always append a new row.
    /// </summary>
    public class RewardHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Required]
        public int PointsEarned { get; set; }

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty; // e.g. "In-store purchase", "Demo points"

        public DateTime EarnedAt { get; set; } = DateTime.UtcNow;
    }
}