using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailToWifeCreator.Creators;

namespace MailToWifeCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringCreator bodyCreator = new BodyCreator();

            IStringCreator subjectCreator = new SubjectCreator();

            IMailSender mailSender = new OutlookSender();

            mailSender.Send(new MailInfo
            {
                To = "jolanta.walkowska@dsm.com",
                Subject = subjectCreator.GetString(),
                Body = bodyCreator.GetString()
            });
        }
    }
}
