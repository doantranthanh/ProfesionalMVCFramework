using System.ComponentModel;
using ConfigViewer.Domain.Concrete;

namespace ConfigViewer.Domain.Entities
{
    public interface IXlnConfigCommon
    {
        bool ProductionMode { get; set; }
        string WcfUrl { get; set; }
        string WcfUserName { get; set; }
        string WcfPassword { get; set; }
        string CompanyName { get; set; }
        string BuildingName { get; set; }
        string StreetName { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
    }

    public class XlnConfigCommon : IXlnConfigCommon
    {
        [Config]
        [DisplayName("Production Mode")]
        public bool ProductionMode { get; set; }

        [Config]
        [DisplayName("Wcf Url")]
        public string WcfUrl { get; set; }

        [Config]
        [DisplayName("Wcf UserName")]
        public string WcfUserName { get; set; }

        [Config]
        [DisplayName("Wcf Password")]
        public string WcfPassword { get; set; }

        [Config]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Config]
        [DisplayName("Buliding Name")]
        public string BuildingName { get; set; }

        [Config]
        [DisplayName("Wcf Url")]
        public string StreetName { get; set; }

        [Config]
        [DisplayName("City")]
        public string City { get; set; }

        [Config]
        [DisplayName("Post Code")]
        public string PostalCode { get; set; }
    }
}
