using TheOmenDen.Shared.Responses;

namespace TheOmenDen.Shared.Logging.Options;
internal class ApiExceptionOptions
{
    /// <summary>
    /// Determines what details for the <see cref="Exception"/> provided need to be retrieved from the <seealso cref="HttpContext"/> in order to be provided into the <seealso cref="OperationOutcome"/>
    /// </summary>
    public Action<HttpContext, Exception, OperationOutcome> AddResponseDetails { get; set; }

    /// <summary>
    /// Determines the <see cref="LogLevel"/> needed to properly report the thrown <see cref="Exception"/>
    /// </summary>
    public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
}
