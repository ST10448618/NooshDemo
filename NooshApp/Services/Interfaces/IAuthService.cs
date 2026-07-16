using NooshApp.Models;

namespace NooshApp.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Generates and "sends" (simulated) an OTP for the given phone number.
        /// Creates the user account if it doesn't exist yet.
        /// </summary>
        Task<string> RequestOtpAsync(string phoneNumber);

        /// <summary>
        /// Validates the submitted OTP against what was generated.
        /// Returns the User if valid, null if invalid or expired.
        /// </summary>
        Task<User?> VerifyOtpAsync(string phoneNumber, string submittedOtp);
    }
}