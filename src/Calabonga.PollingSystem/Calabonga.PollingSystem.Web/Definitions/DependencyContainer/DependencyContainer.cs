using Calabonga.PollingSystem.Contracts;
using Calabonga.PollingSystem.Web.Definitions.Base;
using Calabonga.PollingSystem.Web.Infrastructure;

namespace Calabonga.PollingSystem.Web.Definitions.DependencyContainer
{
    public class DependencyContainer: AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPollService, PollService>();
        }
    }
}
