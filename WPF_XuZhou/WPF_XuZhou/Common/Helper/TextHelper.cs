using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_XuZhou
{
    public class TextHelper
    {
        public static string DeUnicode(string str)
        {
            Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return reg.Replace(str, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        }
        public static string Between(string str, string leftstr, string rightstr)
        {
            try
            {
                int i = str.IndexOf(leftstr) + leftstr.Length;
                string temp = str.Substring(i, str.IndexOf(rightstr, i) - i);
                return temp;
            }
            catch
            {
                return "";
            }

        }
    }
}
