using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Services
{
    public static class SessionCartStorage
    {
        private static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var s = JsonConvert.SerializeObject(value);
            session.SetString(key, s);
        }

        private static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SaveCart(this ISession session, Cart cart)
        {
            session.SetObjectAsJson(nameof(Cart), cart.Items);
        }

        public static Cart GetCart(this ISession session)
        {
            var items = session.GetObjectFromJson<CartItem[]>(nameof(Cart));

            return items == null ? new Cart(session) : new Cart(session, items);
        }
    }
}
