using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailToWifeCreator.Dictionary
{
    internal static class HelloDictionary
    {
        public static List<string> Hellos; 

        static HelloDictionary()
        {
            Hellos = new List<string>
                {
                    "Dzień dobry",
                    "Witam",
                    "Cześć",
                    "Hej",
                    "Siema",
                    "Hejka",
                    "Siemano",
                    "Elo",
                    "Czołem",
                    "Szczęść Boże",
                    "привет",
                    "Willkommen"
                };
        }
    }
}
