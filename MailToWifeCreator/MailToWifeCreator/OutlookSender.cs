using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailToWifeCreator.Dto;
using Microsoft.Office.Interop.Outlook;

namespace MailToWifeCreator
{
    class OutlookSender : IMailSender
    {
        private MailDto mailDto;

        public void Send(MailDto mailDto)
        {
            this.mailDto = mailDto;

            this.SendMailWithNewWindow();
        }

        private void SendMailWithNewWindow()
        {
            var oApp = new Application();

            var oMailItem = (_MailItem)oApp.CreateItem(OlItemType.olMailItem);

            oMailItem.Body = this.mailDto.Body;

            oMailItem.Subject = this.mailDto.Subject;

            var iPosition = oMailItem.HTMLBody.Length + 1;

            const int iAttachType = (int)OlAttachmentType.olByValue;

            //foreach (var fileInfo in mailInfo.Attachments.Where(f => f.Exists))
            //{
            //    oMailItem.Attachments.Add(fileInfo.FullName, iAttachType, iPosition, string.Empty);
            //    iPosition++;
            //}

            oMailItem.To = mailDto.To;

            oMailItem.CC = mailDto.Cc;

            oMailItem.Display(true);
        }

    }

    
    
    
}
