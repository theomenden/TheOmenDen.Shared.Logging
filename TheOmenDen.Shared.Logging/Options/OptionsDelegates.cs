using Microsoft.Data.SqlClient;
using TheOmenDen.Shared.Responses;

namespace TheOmenDen.Shared.Logging.Options;
/// <summary>
/// Provides configurable logging options delegates to help determine what type of data caused an exception to be thrown.
/// Also provides a way to determine logging levels based off the exception type.
/// </summary>
public static class OptionsDelegates
{
    private const string SqlExceptionName = nameof(SqlException);
    private const string DatabaseExceptionMessage = "- The exception was a database exception.";
    private const string CannotOpenDatabaseMessage = "cannot open database";
    private const string ANetworkRelatedMessage = "a network-related";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="exception"></param>
    /// <param name="operationOutcome"></param>
    public static void UpdateApiErrorResponse(HttpContext context, Exception exception,
        OperationOutcome operationOutcome)
    {
        var exceptionTypeName = exception.GetType().Name;

        if (exceptionTypeName.Equals(SqlExceptionName, StringComparison.OrdinalIgnoreCase))
        {
            operationOutcome.ClientErrorPayload.Message += DatabaseExceptionMessage;
        }
        

        operationOutcome.ClientErrorPayload.Detail += $"{context.Connection.LocalIpAddress}{Environment.NewLine}Trace Identifier: {context.TraceIdentifier}";
    }

    public static LogLevel DetermineLogLevel(Exception exception) =>
    exception.Message.StartsWith(CannotOpenDatabaseMessage, StringComparison.OrdinalIgnoreCase)
    || exception.Message.StartsWith(ANetworkRelatedMessage, StringComparison.OrdinalIgnoreCase)
    ? LogLevel.Critical
    : LogLevel.Error;
}
