using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ConfigViewer.Domain.Abstract;

namespace ConfigViewer.Domain.Concrete
{
    public class XmlConfigEngine : IXmlConfigReader, IXmlConfigWriter
    {
        private readonly IPathProvider _pathProvider;

        public XmlConfigEngine(IPathProvider pathProvider)
        {
            _pathProvider = pathProvider;
        }

        public XDocument XmlFile { get; set; }

        public virtual XDocument GetXmlFile(string xmlPath)
        {
            return XDocument.Load(_pathProvider.MapPath(xmlPath));
        }

        public string GetConfigValue(XDocument xdoc, string section, string key)
        {
            return xdoc.Descendants(section)
                    .Where(x => x.Element(key) != null)
                    .Select(x =>
                    {
                        var xElement = x.Element(key);
                        return xElement != null ? xElement.Value : null;
                    })
                    .FirstOrDefault(); 
        }

        public T LoadConfigs<T>(Type configType,string xmlPath, string section, T _object)
        {
            XmlFile = GetXmlFile(xmlPath);

            var configProperties = configType.GetProperties();
            foreach (var configProperty in configProperties.Where(configProperty => configProperty.GetCustomAttributes(typeof(ConfigAttribute), false).Length > 0))
            {
                var val = Convert.ChangeType(GetConfigValue(XmlFile, section, configProperty.Name), configProperty.PropertyType);

                configProperty.SetValue(_object, val,null);
            }

            return _object;
        }

        public IEnumerable<string> GetAllFirstChildElements(string xmlPath, string rootElement)
        {
            XmlFile = GetXmlFile(xmlPath);

            var list = (from e in XmlFile.Descendants(rootElement).Elements()
                select e.Name.LocalName).ToList();

            return list;
        }

        public XDocument UpdateXmlElement<T>(T type, string xmlPath, string rootElement, string section, T _object)
        {
            XmlFile = GetXmlFile(xmlPath);

            var xElement = XmlFile.Element(rootElement);

            if (xElement != null)
            {
                var target = xElement.Elements(section).Single();
                var configProperties = typeof(T).GetProperties();
                foreach (var configProperty in configProperties.Where(configProperty => configProperty.GetCustomAttributes(typeof(ConfigAttribute), false).Length > 0))
                {
                    var name = configProperty.Name;
                    var val = configProperty.GetValue(_object, null);

                    if (!FilterdXmlFileType().Contains(name))
                    {
                        var element = target.Element(name);
                        if (element != null)
                            element.Value = val.ToString();
                    }
                    else
                        target.Value = val.ToString();

                }
            }

            return XmlFile;
        }

        public void SaveXmlFile(string xmlPath)
        {          
            XmlFile.Save(HttpContext.Current.Server.MapPath(xmlPath));
        }

        private static List<string> FilterdXmlFileType()
        {
            return new List<string>()
            {
                "MaintenanceMode"
            };
        } 
    }
}
