using System.ComponentModel;
using ConfigViewer.Domain.Concrete;

namespace ConfigViewer.Domain.Entities
{
    public interface IXlnConfiguration
    {
        bool MaintenanceMode { get; set; }
    }
    public class XlnConfiguration : IXlnConfiguration
    {
        [Config]
        [DisplayName("Maintenance Mode")]
        public bool MaintenanceMode { get; set; }
    }
}
