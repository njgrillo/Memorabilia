using JetBrains.Annotations;
using System;

namespace Framework.Extension
{
    public static class StringExtensions
    {
        [ContractAnnotation("null => true")]
        public static bool IsNullOrEmpty([CanBeNull] this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool ToBoolean([CanBeNull] this string value)
        {
            return !value.IsNullOrEmpty() && Convert.ToBoolean(value.ToInt32());
        }

        public static byte[] ToByte(this string value)
        {
            if (value == null)
                return null;

            var newByte = new byte[value.Length / 2];

            for (var i = 0; i < value.Length / 2; i++)
            {
                newByte[i] = Convert.ToByte(value.Substring(2 * i, 2), 16);
            }

            return newByte;
        }

        public static int ToInt32([CanBeNull] this string value)
        {
            return !value.IsNullOrEmpty() ? Convert.ToInt32(value) : 0;
        }
    }
}
