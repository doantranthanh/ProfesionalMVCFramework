using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfigViewer.Helper
{
    public static class StringHelper
    {
        public static string UpperFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        } 
    }
}