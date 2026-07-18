using NooshApp.Models;
using NooshApp.Repositories.Interfaces;
using NooshApp.Services.Interfaces;

namespace NooshApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private static readonly Random _random = new Random();

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RequestOtpAsync(string phoneNumber)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);

            if (user == null)
            {
                user = await _userRepository.CreateAsync(phoneNumber);
            }

            // Generate a 6-digit OTP. In production this would be sent via SMS
            // (e.g. Twilio, Clickatell) instead of being simulated here.
            var otp = _random.Next(100000, 999999).ToString();

            user.CurrentOtp = otp;
            user.OtpExpiresAt = DateTime.UtcNow.AddMinutes(5);

            await _userRepository.UpdateAsync(user);

            return otp; // returned so the Controller can display it on-screen (simulation only!)
        }

        public async Task<User?> VerifyOtpAsync(string phoneNumber, string submittedOtp)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);

            if (user == null || user.CurrentOtp == null || user.OtpExpiresAt == null)
            {
                return null;
            }

            bool isExpired = DateTime.UtcNow > user.OtpExpiresAt.Value;
            bool isMatch = user.CurrentOtp == submittedOtp;

            if (!isMatch || isExpired)
            {
                return null;
            }

            // OTP consumed — clear it so it can't be reused.
            user.CurrentOtp = null;
            user.OtpExpiresAt = null;
            await _userRepository.UpdateAsync(user);

            return user;
        }
    }
}