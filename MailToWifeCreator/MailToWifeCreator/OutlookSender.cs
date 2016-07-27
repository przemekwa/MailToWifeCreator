using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace MailToWifeCreator
{
    class OutlookSender : IMailSender
    {
        private MailInfo mailInfo;

        public void Send(MailInfo mailInfo)
        {
            this.mailInfo = mailInfo;

            this.SendMailWithNewWindow();
        }

        private void SendMailWithNewWindow()
        {
            var oApp = new Application();

            var oMailItem = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);

            oMailItem.Body = this.mailInfo.Body;

            oMailItem.Subject = this.mailInfo.Subject;

            var iPosition = oMailItem.HTMLBody.Length + 1;

            const int iAttachType = (int)OlAttachmentType.olByValue;

            //foreach (var fileInfo in mailInfo.Attachments.Where(f => f.Exists))
            //{
            //    oMailItem.Attachments.Add(fileInfo.FullName, iAttachType, iPosition, string.Empty);
            //    iPosition++;
            //}

            oMailItem.To = mailInfo.To;

            oMailItem.CC = mailInfo.Cc;

            oMailItem.Display(true);
        }

    }

    
    
    
}
