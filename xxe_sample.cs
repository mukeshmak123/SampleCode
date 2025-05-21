using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml;

// This is a sample code for XXE vulnerability in ASP.NET Core
// This code is intentionally vulnerable and should not be used in production
// The code demonstrates how to create an XML document from a string input
// and how to parse it using XmlDocument class
// The code is vulnerable to XXE attacks if the input XML contains external entities
// The code does not validate the input XML and does not disable DTD processing
// The code is vulnerable to XXE attacks if the input XML contains external entities
// The code does not validate the input XML and does not disable DTD processing
// The code is vulnerable to XXE attacks if the input XML contains external entities
namespace WebFox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XxeTest1 : ControllerBase
    {

        [HttpGet("{xmlString}")]
        public void DoXxe(String xmlString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            // The following line is vulnerable to XXE attacks
        }
    }
}
// The code does not validate the input XML and does not disable DTD processing
public class XxeTest2
{
    public void DoXxe(String xmlString)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.XmlResolver = null; // Disable external entity resolution
        xmlDoc.LoadXml(xmlString);
        // XXE vulnerability is now mitigated
    }
}
