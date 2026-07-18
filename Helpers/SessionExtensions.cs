using Microsoft.AspNetCore.Http;

namespace NooshApp.Helpers
{
    /// <summary>
    /// Centralizes how we read/write the logged-in user's identity in Session,
    /// so the key name and logic only exist in one place.
    /// </summary>
    public static class SessionExtensions
    {
        private const string UserIdKey = "LoggedInUserId";
        private const string PhoneNumberKey = "LoggedInPhoneNumber";

        public static void SetLoggedInUser(this ISession session, int userId, string phoneNumber)
        {
            session.SetInt32(UserIdKey, userId);
            session.SetString(PhoneNumberKey, phoneNumber);
        }

        public static int? GetLoggedInUserId(this ISession session)
        {
            return session.GetInt32(UserIdKey);
        }

        public static string? GetLoggedInPhoneNumber(this ISession session)
        {
            return session.GetString(PhoneNumberKey);
        }

        public static void ClearLoggedInUser(this ISession session)
        {
            session.Remove(UserIdKey);
            session.Remove(PhoneNumberKey);
        }

        public static bool IsLoggedIn(this ISession session)
        {
            return session.GetInt32(UserIdKey).HasValue;
        }
    }
}