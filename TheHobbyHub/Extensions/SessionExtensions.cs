// using Microsoft.CodeAnalysis.CSharp.Syntax;  // do we need this? - I copied it from DVDCentral
using Newtonsoft.Json;

namespace CG.DVDCentral.UI.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
