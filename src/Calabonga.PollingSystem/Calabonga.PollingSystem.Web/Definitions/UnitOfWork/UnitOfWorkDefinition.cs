using Calabonga.PollingSystem.Application;
using Calabonga.PollingSystem.Web.Definitions.Base;
using Calabonga.UnitOfWork;

namespace Calabonga.PollingSystem.Web.Definitions.UnitOfWork
{
    public class UnitOfWorkDefinition: AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddUnitOfWork<ApplicationDbContext>();
        }
    }
}
