using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ZhongXinPay.Entity
{
    public class Account
    {
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("statusText")]
        public string StatusText { get; set; }
    }
}