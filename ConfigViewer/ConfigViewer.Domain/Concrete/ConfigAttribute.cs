using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigViewer.Domain.Concrete
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigAttribute : Attribute
    {

    }
}
