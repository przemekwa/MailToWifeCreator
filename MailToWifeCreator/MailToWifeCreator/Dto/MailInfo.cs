﻿using System.Collections.Generic;
using System.IO;

namespace MailToWifeCreator.Dto
{
    public class MailDto
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sign { get; set; }
        public IList<FileInfo> Attachments { get; set; }
    }
}