using System;

namespace Seminar.Common.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
        public static string GetResourceKey(this Enum value)
        {
            var attribute = value.GetAttribute<ResourceKeyAttribute>();
            return attribute == null ? value.ToString() : attribute.Key;
        }
    }
}
