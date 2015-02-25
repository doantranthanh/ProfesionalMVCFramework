using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigViewer.Domain.Abstract
{
    public interface IApplicationPool
    {
        string GetIISPath();
        IEnumerable<string> GetListAppPools();
        void RecyleApplicationPool(string appPoolName);
    }
}
