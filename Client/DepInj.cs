using Client.Interfaces;
using Client.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DepInj
    {
        public static void RegisterBlobStorageClient(
            this IServiceCollection services, Action<BlobStorageClientOptions> configureOptions)
        {
            services.ConfigureServiceOptions<BlobStorageClientOptions>((_, options) => configureOptions(options));
            services.AddTransient<IBlobStorageClient, BlobStorageClient>();
        }
        
        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
    }
}