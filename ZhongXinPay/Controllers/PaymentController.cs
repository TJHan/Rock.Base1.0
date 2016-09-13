using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZhongXinPay.Entity;
using System.Xml.Serialization;
using System.Xml;
using Rock.Base.DataAccess;
using System.Configuration;
using Rock.Base;
namespace ZhongXinPay.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            BaseDBContext db = new BaseDBContext(ConfigurationManager.ConnectionStrings["ROCKConnDebugPic"].ToString());
            //db.insertTest();
            //db.UpdateTest();
            db.PagingTest();
            return View();
        }

        public ActionResult Call()
        {
            string xml = @"<?xml version=""1.0"" encoding=""GBK""?>
<stream>
<action>DLBREGSN</action>
<userName>xinjinqiao</userName>
<mainAccNo>8110701074900006568</mainAccNo>
<appFlag>2</appFlag>
<accGenType>0</accGenType>
<subAccNo></subAccNo>
<subAccNm>test1</subAccNm>
<accType>03</accType>
<calInterestFlag>0</calInterestFlag>
<interestRate></interestRate>
<overFlag>0</overFlag>
<overAmt></overAmt>
<overRate></overRate>
<autoAssignInterestFlag>0</autoAssignInterestFlag>
<autoAssignTranFeeFlag>0</autoAssignTranFeeFlag>
<feeType>0</feeType>
<realNameParm>0</realNameParm>
<subAccPrintParm>0</subAccPrintParm>
<mngNode>1</mngNode>
<vtlCustNm>test1</vtlCustNm>
<legalPersonNm>韩同军</legalPersonNm>
<custCertType>0</custCertType>
<custCertNo>370213198607214818</custCertNo>
<branch>001</branch>
<commAddress>qingdao</commAddress>
<list name=""VilcstDataList"">
<row>
<contactName>mrhan</contactName>
<contactPhone>13884967713</contactPhone>
<mailAddress>hantongjun7@163.com</mailAddress>
</row>
</list>
</stream>";
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(xml);
            WebRequest request = WebRequest.Create("http://192.168.1.11:6789");
            request.Method = "POST";
            Stream postData = request.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
            string result = reader.ReadToEnd();
            Account entity = new Account();
            XmlSerializer xmlser = new XmlSerializer(typeof(Account));

            //entity = (Account)xmlser.Deserialize(reader);
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(reader);

            var dd = xmlser.Deserialize(reader);
            return View((object)result);
        }
    }
}