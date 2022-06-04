using Calabonga.PollingSystem.Web.Definitions.Base;

namespace Calabonga.PollingSystem.Web.Definitions.Blazors
{
    public class BlazorDefinition: AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddServerSideBlazor();
        }

        public override void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
        {
            app.MapBlazorHub();
        }
    }
}
