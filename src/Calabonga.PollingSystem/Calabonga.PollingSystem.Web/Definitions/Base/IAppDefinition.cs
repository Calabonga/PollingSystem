namespace Calabonga.PollingSystem.Web.Definitions.Base
{
    /// <summary>
    /// // Calabonga: update summary (2022-05-02 10:02 IAppDefinition)
    /// </summary>
    public interface IAppDefinition
    {
        /// <summary>
        /// // Calabonga: update summary (2022-05-02 10:02 IAppDefinition)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// // Calabonga: update summary (2022-05-02 10:02 IAppDefinition)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="environment"></param>
        void ConfigureApplication(WebApplication app, IWebHostEnvironment environment);
    }
}
