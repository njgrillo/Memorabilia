using System;
using System.Text;

namespace Framework.Extension
{
    public static class ByteExtensions
    {
        public static byte[] Reverse(this byte[] data)
        {
            var szData = data.Length;
            byte[] b = new byte[szData];

            for (var i = 0; i < szData; i++)
                b[szData - 1 - i] = data[i];

            return b;
        }

        public static string ToBase64ForUrl(this byte[] input)
        {
            var result = new StringBuilder(Convert.ToBase64String(input).TrimEnd('='));
            return result.Replace('+', '-').Replace('/', '_').ToString();
        }

        public static string ToHex(this byte[] data)
        {
            var result = string.Empty;
            if (data.Length == 0) 
                return result;

            foreach (byte t in data)
            {
                result = $"{result}{Convert.ToString(t, 16).PadLeft(2, '0')}";
            }

            return result;
        }
    }
}
