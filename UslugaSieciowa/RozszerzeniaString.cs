using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UslugaSieciowa
{
    public static class RozszerzeniaString
    {
        public static string Do10Znakow(this string text)
        {
            if (text.Length >= 10)
                return text.Substring(0, 10);
            else
                return text.PadRight(10, 'X');
        }

    }
}