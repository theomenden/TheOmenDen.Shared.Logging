using System.Net;
using TheOmenDen.Shared.Logging.Templates;

namespace TheOmenDen.Shared.Logging.Http;
/// <summary>
/// <inheritdoc cref="DelegatingHandler"/> 
/// Provides a way to log <see cref="MetaData"/> from a <seealso cref="HttpRequestMessage"/> and <seealso cref="HttpResponseMessage"/>
/// </summary>
/// <remarks></remarks>
internal sealed class DelegatingLogHandler: DelegatingHandler
{
    private readonly ILogger<DelegatingLogHandler> _logger;
    public DelegatingLogHandler(ILogger<DelegatingLogHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var loggingMetaData = BuildRequestMetaData(request);
        var response = await base.SendAsync(request, cancellationToken);
        loggingMetaData = BuildResponseMetaData(loggingMetaData, response);
        await SendToLoggerAsync(loggingMetaData);
        return response;
    }

    private static LogLevel DetermineLogLevel(HttpStatusCode statusCode)
    {
        return (int)statusCode switch
        {
            >= 500 => LogLevel.Critical,
            >= 400 => LogLevel.Error,
            _ => LogLevel.Information
        };
    }

    private static MetaData BuildRequestMetaData(HttpRequestMessage request)
    {
        return new()
        {
            RequestMethod = request.Method.Method,
            RequestTimestamp = DateTime.UtcNow,
            RequestUri = request.RequestUri?.ToString() ?? String.Empty,
        };
    }

    private static MetaData BuildResponseMetaData(MetaData logMetaData, HttpResponseMessage response)
    {
        logMetaData.ResponseStatusCode = response.StatusCode;
        logMetaData.ResponseTimestamp = DateTime.UtcNow;
        logMetaData.ResponseContentType = response.Content.Headers.ContentType?.MediaType ?? String.Empty;
        return logMetaData;
    }

    private Task SendToLoggerAsync(MetaData logMetaData)
    {
        var logLevel = DetermineLogLevel(logMetaData.ResponseStatusCode);
        _logger.Log(logLevel, EventIDs.EventIdHttpClient, "HttpContext Provided Metadata {@MetaData}",logMetaData);
        return Task.CompletedTask;
    }
}
