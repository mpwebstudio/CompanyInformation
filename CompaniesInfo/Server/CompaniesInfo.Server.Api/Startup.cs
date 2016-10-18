using Microsoft.Owin;

[assembly: OwinStartup(typeof(CompaniesInfo.Server.Api.Startup))]

namespace CompaniesInfo.Server.Api
{
    using System.Reflection;
    using System.Web.Http;
    using Newtonsoft.Json.Serialization;
    using Owin;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpConfig.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            AutoMapperConfig.RegisterMappings(Assembly.Load("CompaniesInfo.Server.DataTransferModels"));

            app.UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);

        }
    }
}
