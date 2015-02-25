using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigViewer.Domain.Entities
{
    public class XlnMainSection
    {
        public List<string> PublicWebsiteSections { get; set; }
        public List<string> ConfigurationSections { get; set; }
        public List<string> ApplicationPools { get; set; } 
    }
}
