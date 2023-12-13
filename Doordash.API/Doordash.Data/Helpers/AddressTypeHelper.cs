using Doordash.Data.Models.Addresses;
using System.Collections.Generic;

namespace Doordash.Data.Helpers
{
    public static class AddressTypeHelper
    {
        private static readonly Dictionary<AddressType, string> TypeToStringMap = new Dictionary<AddressType, string>
    {
        { AddressType.Business, "Business" },
        { AddressType.Personal, "Personal" }
    };

        public static string GetString(AddressType type)
        {
            return TypeToStringMap.TryGetValue(type, out var value) ? value : null;
        }
    }
}
