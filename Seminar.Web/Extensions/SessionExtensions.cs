using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar.Web.Extensions
{
    public static class SessionExtensions
    {
        /// <summary>
        /// Get a complex data saved in ISession
        /// </summary>
        /// <typeparam name="T"> The type of the complex data </typeparam>
        /// <param name="session"></param>
        /// <param name="key"> The key used to find data </param>
        /// <returns> The complex data </returns>
        public static T GetObject<T>(this ISession session, string key) where T: new()
        {
            string dataJson = session.GetString(key);
            if(string.IsNullOrEmpty(dataJson))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(dataJson);
        }

        /// <summary>
        /// Get a complex data saved in ISession
        /// </summary>
        /// <typeparam name="T"> The type of the complex data </typeparam>
        /// <param name="session"></param>
        /// <param name="key"> The key used to find data </param>
        /// <returns> true if exist, false otherwise </returns>
        public static bool IsExistObject<T>(this ISession session, string key)
        {
            string dataJson = session.GetString(key);
            return !string.IsNullOrEmpty(dataJson);
            
        }

        /// <summary>
        /// Set a complex data into ISession
        /// </summary>
        /// <typeparam name="T"> The type of the complex data </typeparam>
        /// <param name="session"></param>
        /// <param name="key"> key for the complex data </param>
        /// <param name="value"> value of the complex data </param>
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
