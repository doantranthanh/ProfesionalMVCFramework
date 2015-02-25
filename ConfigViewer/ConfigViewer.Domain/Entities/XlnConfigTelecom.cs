using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigViewer.Domain.Concrete;

namespace ConfigViewer.Domain.Entities
{
    public interface IXlnConfigTelecom
    {
        string EnableLiveChat { get; set; }
        string ChatPopupTimer { get; set; }
        string ChatCookieExpirationDays { get; set; }
        string RequireSecure { get; set; }      
    }

    public class XlnConfigTelecom : IXlnConfigTelecom
    {
        [Config]
        public string EnableLiveChat { get; set; }

        [Config]
        public string ChatPopupTimer { get; set; }

        [Config]
        public string ChatCookieExpirationDays { get; set; }

        [Config]
        public string RequireSecure { get; set; }
    }
}
