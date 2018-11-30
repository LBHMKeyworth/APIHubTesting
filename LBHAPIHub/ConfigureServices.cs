using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHAPIHub.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace LBHAPIHub
{
    public class ConfigureServices
    {
        public static void ConfigureLogging(this IServiceCollection services, IConfiguration configuration, GitHubSettings settings)
        {
            services.AddLogging(configure =>
            {
                configure.AddConfiguration(configuration.GetSection("Logging"));
                configure.AddConsole();
                configure.AddDebug();
                //logs errors to sentry if configured
                if (!string.IsNullOrEmpty(settings.SentrySettings?.Url))
                    configure.AddProvider(new SentryLoggerProvider(settings.SentrySettings?.Url, settings.SentrySettings?.Environment));
            });
        }
    }
}
