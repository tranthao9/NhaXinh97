using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaXinhBUS.common
{
	public static class RandomExtension
	{
        public static string NextString(this Random random, int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

            IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
            char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();
            return new string(arr);
        }
    }
}
