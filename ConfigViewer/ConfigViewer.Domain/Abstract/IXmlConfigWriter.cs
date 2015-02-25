using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ConfigViewer.Domain.Abstract
{
    public interface IXmlConfigWriter
    {
        XDocument UpdateXmlElement<T>(T type, string xmlPath, string rootElement, string section, T _object);
        void SaveXmlFile(string xmlPath);
    }
}
