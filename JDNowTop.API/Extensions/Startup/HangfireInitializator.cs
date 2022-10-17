using Hangfire;
using Hangfire.MemoryStorage;

namespace JDNowTop.API.Extensions.Startup
{
    public static class HangfireInitializator
    {
        public static void InitializeHangfire(this IServiceCollection _services)
        {
            _services.AddHangfire(configuration =>
                configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage());
            _services.AddHangfireServer();
        }
    }
}
