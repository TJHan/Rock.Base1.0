using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ZhongXinPay.Entity;

namespace ZhongXinPay.Common
{
    public class XMLSerializable
    {
        public T XMLSer<T>(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                return (T)xmls.Deserialize(sr);
            }
        }
    }
}