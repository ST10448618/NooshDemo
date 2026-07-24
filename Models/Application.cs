using System.ComponentModel.DataAnnotations;

namespace NooshApp.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Shortlisted,
        Rejected
    }

    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string DesiredPosition { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? CoverLetter { get; set; }

        [Required]
        [MaxLength(300)]
        public string CvFilePath { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string CvOriginalFileName { get; set; } = string.Empty;

        public int KeywordScore { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}