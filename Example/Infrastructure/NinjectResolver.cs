using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http.Dependencies;
using Example.Models;
using Ninject;
using Ninject.Web.Common;

namespace Example.Infrastructure
{
    public class NinjectResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel()) { }

        public NinjectResolver(IKernel ninjectKernel)
        {
            kernel = ninjectKernel;
            AddBindings(kernel);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose() { }

        private void AddBindings(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>().InSingletonScope();
            kernel.Bind<IContentNegotiator>().To<CustomNegotiator>();
        }
    }
}