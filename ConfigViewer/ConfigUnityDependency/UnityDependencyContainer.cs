using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ConfigUnityDependency
{
    public class UnityDependencyContainer : IDisposable
    {
        private static UnityDependencyContainer _instance;
        private static readonly object Sync = new object();
        private IUnityContainer _container = new UnityContainer();

        private UnityDependencyContainer()
        {
        }

        public void Clear()
        {
            Dispose();
        }

        public IUnityContainer Container
        {
            get { return _container; }
        }

        public static UnityDependencyContainer GetCurrent()
        {
            if (_instance == null || _instance._container == null)
            {
                lock (Sync)
                {
                    _instance = new UnityDependencyContainer();
                }
            };

            return _instance;
        }

        public UnityConfigurationSection UnityConfig(string name)
        {
            return (UnityConfigurationSection)ConfigurationManager.GetSection(name);
        }

        public void LoadConfiguration(string name)
        {
            _container.LoadConfiguration(UnityConfig(name));
        }

        public void Register<TFrom, TTo>(bool isTransient = false) where TTo : TFrom
        {
            if (isTransient)
            {
                _container.RegisterType<TFrom, TTo>();
            }
            else
            {
                _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
            }
        }

        public void Register<TFrom, TTo>(string name) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(name, new ContainerControlledLifetimeManager());
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            _container.RegisterType(tFrom, tTo);
        }

        public void Register<T>(T instance) where T : class
        {
            _container.RegisterInstance<T>(instance);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public void Dispose()
        {
            _container.Dispose();
            _container = null;
        }
    }
}