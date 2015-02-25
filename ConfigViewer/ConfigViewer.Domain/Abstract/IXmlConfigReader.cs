using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ConfigViewer.Domain.Entities;

namespace ConfigViewer.Domain.Abstract
{
    public interface IXmlConfigReader
    {
        XDocument GetXmlFile(string xmlPath);
        string GetConfigValue(XDocument xdoc, string section, string key);
        T LoadConfigs<T>(Type configType, string xmlPath, string section, T _object);
        IEnumerable<string> GetAllFirstChildElements(string xmlPath, string rootElement);
    }
}
