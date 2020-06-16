using Logic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyWiki
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            if (ContainsObject(session, key))
            {
                DeleteObject(session, key);
            }
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static bool ContainsObject(this ISession session, string key)
        {
            return session.Get(key) != null;
        }
        public static void DeleteObject(this ISession session, string key)
        {
            session.Remove(key);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
