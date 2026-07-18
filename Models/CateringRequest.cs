using System.ComponentModel.DataAnnotations;

namespace NooshApp.Models
{
    public enum CateringStatus
    {
        New,
        Contacted,
        Confirmed,
        Declined
    }

    /// <summary>
    /// A catering enquiry submitted through the Catering page.
    /// </summary>
    public class CateringRequest
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
        public DateTime EventDate { get; set; }

        [Required]
        [Range(1, 1000)]
        public int GuestCount { get; set; }

        [Required]
        [MaxLength(200)]
        public string EventLocation { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? AdditionalNotes { get; set; }

        public CateringStatus Status { get; set; } = CateringStatus.New;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}