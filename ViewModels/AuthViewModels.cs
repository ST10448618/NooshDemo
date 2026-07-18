using System.ComponentModel.DataAnnotations;

namespace NooshApp.ViewModels
{
    /// <summary>
    /// Step 1 of login: customer enters their phone number.
    /// </summary>
    public class PhoneLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }

    /// <summary>
    /// Step 2 of login: customer enters the OTP they "received".
    /// </summary>
    public class VerifyOtpViewModel
    {
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the code.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Code must be 6 digits.")]
        [Display(Name = "Verification Code")]
        public string Otp { get; set; } = string.Empty;
    }
}