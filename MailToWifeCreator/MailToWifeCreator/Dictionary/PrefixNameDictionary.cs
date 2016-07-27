using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailToWifeCreator.Dictionary
{
    internal static class PrefixNameDictionary
    {
        public static List<string> prefixes; 

        static PrefixNameDictionary()
        {
            prefixes = new List<string>
                {
                    "Jolka",
                    "Jola",
                    "Perełko",
                    "Żonka",
                    "Żona"
                };
        }
    }
}
