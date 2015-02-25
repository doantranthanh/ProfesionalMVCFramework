using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using ConfigViewer.Domain.Abstract;

namespace ConfigViewer.Domain.Concrete
{
    public class ApplicationPoolsEngine : IApplicationPool
    {
        public string IISApplicationPath { get; set; } 
 
        public string GetIISPath()
        {
           return HttpContext.Current.Server.MapPath("/");
        }

        public IEnumerable<string> GetListAppPools()
        {
            string serverName = "LocalHost";

            IISApplicationPath = String.Format("IIS://{0}/w3svc",serverName);

            var listApplicationPool = new List<string>();

            if (DirectoryEntry.Exists(IISApplicationPath))
            {
                var w3SVC = new DirectoryEntry(IISApplicationPath);

                foreach (DirectoryEntry site in w3SVC.Children)
                {
                    if (String.Equals(site.Name, "APPPOOLS", StringComparison.OrdinalIgnoreCase))
                    {
                        listApplicationPool.AddRange(from DirectoryEntry child in site.Children
                                                     where child.Name.Contains(".xln")
                                                     select child.Name);
                    }
                }    
            }

            return listApplicationPool;
        }

        public void RecyleApplicationPool(string appPoolName)
        {
            if (String.IsNullOrEmpty(IISApplicationPath))
                IISApplicationPath = "IIS://localhost/W3SVC";

            var appPoolPath = new StringBuilder();
            appPoolPath.Append(IISApplicationPath);
            appPoolPath.Append("/AppPools/");
            appPoolPath.Append(appPoolName);

            using (DirectoryEntry appPoolEntry = new DirectoryEntry(appPoolPath.ToString()))
            {
                appPoolEntry.Invoke("Recycle", null);
                appPoolEntry.Close();
            }
        }
    }
}
