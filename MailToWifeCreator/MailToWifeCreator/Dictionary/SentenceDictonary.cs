using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailToWifeCreator.Dictionary
{
    static class SentenceDictonary
    {
        public static List<string> Sentence;

        static SentenceDictonary()
        {
            Sentence = new List<string>
                {
                    "Jak tam dojazd?",
                    "Jak się czujesz?",
                    "Lubisz mnie?",
                    "Jakie plany na dziś?",
                    "Jak tam nastawienie do pracy?",
                    "Dobrze się jechało?",
                    "Samochód śmiga?",
                    "Jak tam samopoczucie?",
                    "Jesteś naprawdę fajna!",
                    "Kocham Cię!!!",
                    "Masz ochotę na coś specjalnego?",
                    "Mam ochote się z Tobą kochać",
                    "Jak tam wczoraj, było ok, jesteś zadowolona?"
                };
        }
    }
}
