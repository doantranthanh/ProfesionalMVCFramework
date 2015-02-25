using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Concrete;
using Microsoft.Practices.Unity;
using PublicWebsite.Common.Unity;

namespace ConfigViewer.Domain
{
    public class MainEntry
    {
        public static void Main()
        {
            var container = BuildUnityContainer();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = UnityDependencyContainer.GetCurrent().Container;
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyContainer.GetCurrent().Register<IPathProvider, ServerPathProvider>();
        }
    }
}
