namespace Calabonga.PollingSystem.Web.Definitions.Base
{
    /// // Calabonga: update summary (2022-05-02 10:13 AppDefinitionExtensions)
    /// <summary>
    /// </summary>
    public static class AppDefinitionExtensions
    {
        /// <summary>
        /// // Calabonga: update summary (2022-05-02 10:13 AppDefinitionExtensions)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="builder"></param>
        /// <param name="entryPointsAssembly"></param>
        public static void AddDefinitions(this IServiceCollection source, WebApplicationBuilder builder,
            params Type[] entryPointsAssembly)
        {
            var definitions = new List<IAppDefinition>();

            foreach (var entryPoint in entryPointsAssembly)
            {
                var types = entryPoint.Assembly.ExportedTypes.Where(x =>
                    !x.IsAbstract && typeof(IAppDefinition).IsAssignableFrom(x));
                var instances = types.Select(Activator.CreateInstance).Cast<IAppDefinition>();
                definitions.AddRange(instances);
            }

            definitions.ForEach(app => app.ConfigureServices(source, builder.Configuration));
            source.AddSingleton(definitions as IReadOnlyCollection<IAppDefinition>);
        }

        /// <summary>
        /// // Calabonga: update summary (2022-05-02 10:13 AppDefinitionExtensions)
        /// </summary>
        /// <param name="source"></param>
        public static void UseDefinitions(this WebApplication source)
        {
            var definitions = source.Services.GetRequiredService<IReadOnlyCollection<IAppDefinition>>();
            var environment = source.Services.GetRequiredService<IWebHostEnvironment>();
            foreach (var endpoint in definitions)
            {
                endpoint.ConfigureApplication(source, environment);
            }
        }
    }
}