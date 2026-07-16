using System.ComponentModel.DataAnnotations;

namespace NooshApp.Models
{
    /// <summary>
    /// Represents a customer account, identified uniquely by phone number.
    /// No password is stored — authentication is via OTP (see Phase: Authentication).
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? FullName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(6)]
        public string? CurrentOtp { get; set; }

        public DateTime? OtpExpiresAt { get; set; }

        // Navigation property: one user can have many reward history entries.
        // This is populated later once RewardHistory exists (Phase: Rewards).
    }
}