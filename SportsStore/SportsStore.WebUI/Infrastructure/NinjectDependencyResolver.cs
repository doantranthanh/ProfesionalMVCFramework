using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SportsStore.Domain.Abastract;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;
using System.Configuration;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
    }
}