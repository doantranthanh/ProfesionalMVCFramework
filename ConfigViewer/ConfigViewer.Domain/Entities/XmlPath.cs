using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigViewer.Domain.Concrete;

namespace ConfigViewer.Domain.Entities
{
    public interface IXmlPath
    {
        string PublicWebSiteConfig { get; set; }
        string Configuration { get; set; }
    }

    public class XmlPath : IXmlPath
    {
        [Config]
        public string PublicWebSiteConfig { get; set; }

        [Config]
        public string Configuration { get; set; }
    }
}
