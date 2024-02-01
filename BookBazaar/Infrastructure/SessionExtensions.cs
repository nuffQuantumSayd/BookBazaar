using System.Text.Json;

namespace BookBazaar.Infrastructure
{
    // This class is used to serialize and deserialize session data
    public static class SessionExtensions
    {
        // SetJson method
        public static void SetJson(this ISession session, string key, object value)
        {
            // Serialize the object to a string
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // GetJson method
        public static T? GetJson<T>(this ISession session, string key)
        {
            // Deserialize the string to an object
            var sessionData = session.GetString(key);

            // Return the object
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
