using System.Web.Mvc;
using ConfigViewer.Domain.Abstract;
using ConfigViewer.Domain.Concrete;
using Microsoft.Practices.Unity;
using PublicWebsite.Common.Unity;
using Unity.Mvc4;

namespace ConfigViewer
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = UnityDependencyContainer.GetCurrent().Container;

      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        UnityDependencyContainer.GetCurrent().Register<IXmlConfigReader,XmlConfigEngine>();
        UnityDependencyContainer.GetCurrent().Register<IXmlConfigWriter, XmlConfigEngine>();
        UnityDependencyContainer.GetCurrent().Register<IApplicationPool, ApplicationPoolsEngine>();
        UnityDependencyContainer.GetCurrent().Register<IPathProvider, ServerPathProvider>();
    }
  }
}