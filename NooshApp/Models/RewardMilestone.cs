using System.ComponentModel.DataAnnotations;

namespace NooshApp.Models
{
    /// <summary>
    /// A configurable reward tier, e.g. "Spend R300 → Free Drink".
    /// Editable from the Admin Panel (built in a later phase).
    /// </summary>
    public class RewardMilestone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PointsRequired { get; set; }

        [Required]
        [MaxLength(150)]
        public string RewardName { get; set; } = string.Empty; // e.g. "Free Drink"

        public bool IsActive { get; set; } = true;

        public int DisplayOrder { get; set; }
    }
}