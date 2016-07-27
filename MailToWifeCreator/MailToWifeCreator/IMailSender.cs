using MailToWifeCreator.Dto;

namespace MailToWifeCreator
{
    internal interface IMailSender
    {
        void Send(MailDto mailDto);
    }
}