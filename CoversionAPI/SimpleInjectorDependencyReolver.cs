namespace CoversionAPI
{
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http.Dependencies;
    using System.Web.Mvc;

    public class SimpleInjectorDependencyReolver : System.Web.Mvc.IDependencyResolver, 
                                                   System.Web.Http.Dependencies.IDependencyResolver,
                                                   System.Web.Http.Dependencies.IDependencyScope
    
    {
        public Container Container { get; private set; }
        public SimpleInjectorDependencyReolver(Container container)
        {
            if (container == null)
                throw new ArgumentNullException("Container Null or Empty");
            this.Container = container;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        

        public object GetService(Type serviceType)
        {
            if(!serviceType.IsAbstract && typeof(IController).IsAssignableFrom(serviceType))
            {
                return this.Container.GetInstance(serviceType);
            }
            return ((IServiceProvider)this.Container).GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType);
        }

        object IDependencyScope.GetService(Type serviceType)
        {
            return ((IServiceProvider)this.Container).GetService(serviceType);
        }

        

        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            IServiceProvider provider = Container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        public void Dispose()
        {

        }
    }
}