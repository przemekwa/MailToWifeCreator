using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailToWifeCreator.Creators
{
    class SubjectCreator : IStringCreator
    {
        private List<string> subjects;

        private int subNumber;

        public SubjectCreator()
        {
            this.subjects = new List<string>
            {
               "Kolejny piękny dzień",
               "Jolka Jolka",
               "Być albo nie być",
               "Dla Ciebie, dla mnie"
            };

            var random = new Random();

            this.subNumber = random.Next(this.subjects.Count);

        }

        public string GetString()
        {
            return this.subjects[this.subNumber];
        }
    }
}
