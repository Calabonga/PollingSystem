using Calabonga.PollingSystem.Application;
using Calabonga.PollingSystem.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Calabonga.PollingSystem.Web.Definitions.DbContext;

public class DbContextDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
        });
    }
}