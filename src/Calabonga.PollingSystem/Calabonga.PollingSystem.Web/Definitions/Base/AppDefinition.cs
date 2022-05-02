﻿namespace Calabonga.PollingSystem.Web.Definitions.Base;

public abstract class AppDefinition : IAppDefinition
{
    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
         
    }

    public virtual void ConfigureApplication(WebApplication app, IWebHostEnvironment environment)
    {
            
    }
}