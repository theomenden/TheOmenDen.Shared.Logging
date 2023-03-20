using Serilog.Configuration;

namespace TheOmenDen.Shared.Logging.Serilog;
/// <summary>
/// Adds the <c>WithEventType()</c> extension method to <see cref="LoggerConfiguration"/> 
/// </summary>
public static class EnvironmentLoggerConfigurationExtensions
{
    /// <summary>
    /// Adds an <see cref="EventTypeEnricher"/> to the <seealso cref="LoggerConfiguration"/>.
    /// This allows for various template messages based off of provided <see cref="EventIdIdentifier"/> to be logged out. 
    /// </summary>
    /// <param name="enrichmentConfiguration"></param>
    /// <returns><see cref="LoggerConfiguration"/> for further configuration options to be added</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided <paramref name="enrichmentConfiguration"/> is not found</exception>
    public static LoggerConfiguration WithEventType(this LoggerEnrichmentConfiguration enrichmentConfiguration) =>
    enrichmentConfiguration is null
    ? throw new ArgumentNullException(nameof(enrichmentConfiguration))
    : enrichmentConfiguration.With<EventTypeEnricher>();
}
