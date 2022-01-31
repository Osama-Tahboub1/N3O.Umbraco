using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using N3O.Umbraco;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace DemoSite.Web {
    public class Startup : CmsStartup {
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
            : base(webHostEnvironment, configuration) { }

        protected override void ConfigureEndpoints(IUmbracoEndpointBuilderContext umbraco) { }

        protected override void ConfigureMiddleware(IUmbracoApplicationBuilderContext umbraco) {
            // umbraco.AppBuilder.UseCors();
        }
    }
}