using System.Web;
using ConfigViewer.Domain.Abstract;

namespace ConfigViewer.Domain.Concrete
{
    public class ServerPathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}
