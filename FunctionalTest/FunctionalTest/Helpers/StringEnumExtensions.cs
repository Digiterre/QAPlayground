using System;

namespace FunctionalTest.Helpers
{
    public static class StringEnumExtensions
    {
        public static T AsEnum<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException("Type is not enumeration " + enumType.Name);
            }

            return (T) Enum.Parse(enumType, value, true);

        }
            
    }
}
