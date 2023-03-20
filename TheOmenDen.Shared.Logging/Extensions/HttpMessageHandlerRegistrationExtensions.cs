using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using TheOmenDen.Shared.Logging.Http;

namespace TheOmenDen.Shared.Logging.Extensions;
public static class HttpMessageHandlerRegistrationExtensions
{
    /// <summary>
    /// Adds the <see cref="DelegatingLogHandler"/> to the provided <seealso cref="IHttpClientBuilder"/>
    /// </summary>
    /// <param name="clientBuilder"> The supplied <see cref="IHttpClientBuilder"/></param>
    /// <returns><see cref="IHttpClientBuilder"/> for further chaining</returns>
    public static IHttpClientBuilder AddLoggingMessageHandler(this IHttpClientBuilder clientBuilder)
    {
        clientBuilder.AddHttpMessageHandler<DelegatingLogHandler>();

        return clientBuilder;
    }

    /// <summary>
    /// Registers the <see cref="DelegatingLogHandler"/> in the provided <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">The service collection provided</param>
    /// <returns><see cref="IServiceCollection"/> for further chaining</returns>
    public static IServiceCollection AddLoggingMessageHandler(this IServiceCollection services)
    {
        services.TryAddTransient<DelegatingLogHandler>();

        return services;
    }
    /// <summary>
    /// Adds the <see cref="DelegatingLogHandler"/> to the provided <seealso cref="IHttpClientBuilder"/> for ALL <see cref="HttpClient"/>s in the <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services"> The supplied <see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/> for further chaining</returns>
    public static IServiceCollection AddLoggingMessageHandlerToAllClients(this IServiceCollection services)
    {
        services.TryAddTransient<DelegatingLogHandler>();

        services.ConfigureAll<HttpClientFactoryOptions>(options =>
        {
            options.HttpMessageHandlerBuilderActions.Add(builder =>
            {
                builder.AdditionalHandlers.Add(builder.Services.GetRequiredService<DelegatingLogHandler>());
            });
        });

        return services;
    }


}
