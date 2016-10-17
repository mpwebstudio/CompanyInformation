namespace CompaniesInfo.Server.Api
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Common;
    using Data;
    using Data.Common.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                ObjectFactory.Initialize(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<DbContext>().To<CompaniesInfoEntities>().InRequestScope();

            kernel.Bind(k => k
                .From(
                    Common.Constants.CommonServicesAssembly,
                    Common.Constants.DataTransferModelsAssembly,
                    Common.Constants.DataServicesAssembly
                    )
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface());
        }
    }
}