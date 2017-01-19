using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveUp.Net.Common
{
    /// <summary>
    /// Some general extension methodes
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Searches a array for the occurance of another array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="haystack">the array to search in</param>
        /// <param name="needle">the array which should be found in the <paramref name="haystack"/></param>
        /// <returns></returns>
        public static IEnumerable<int> IndexOf<T>(this T[] haystack, T[] needle)
        {
            if ((needle != null) && (haystack.Length >= needle.Length))
            {
                for (int l = 0; l < haystack.Length - needle.Length + 1; l++)
                {
                    if (!needle.Where((data, index) => !haystack[l + index].Equals(data)).Any())
                        yield return l;
                }
            }
        }

        /// <summary>
        /// Converts the byte array to an ASCII encoded string.
        /// </summary>
        /// <param name="data">The byte array to convert</param>
        public static string ToASCII(this byte[] data)
        {
            const int BUFFER_SIZE = 2048;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i += BUFFER_SIZE)
                sb.Append(ConvertByteBlock(data, i, Math.Min(BUFFER_SIZE, data.Length - i)));

            return sb.ToString();
        }

        private static string ConvertByteBlock(byte[] data, int start, int length)
        {
            return Encoding.ASCII.GetString(data, start, length);
        }
    }
}
