using ILogger = Microsoft.Extensions.Logging.ILogger;
namespace TheOmenDen.Shared.Logging.Extensions;

/// <summary>
/// Extensions on <c>Microsoft.Extensions.Logging.</c><see cref="ILogger"/>
/// </summary>
public static class LoggerExtensions
{
    private static readonly Action<ILogger, Exception?> BeforeValidatingMessageTrace = LoggerMessage.Define(
        LogLevel.Debug,
        new EventId(TraceEventIdentifiers.BeforeValidatingMessageTrace.Value, nameof(TraceBeforeValidatingMessage)),
        PipelineBehaviour + " Validating Message"
    );

    private static readonly Action<ILogger, string, string, Exception?> InvalidMessageTrace = LoggerMessage.Define<string, string>(
        LogLevel.Debug,
        new EventId(TraceEventIdentifiers.InvalidMessageTrace.Value, nameof(TraceMessageValidationFailed)),
        PipelineBehaviour + " Invalid Message. {message}. User: {user}"
    );

    private static readonly Action<ILogger, string, string, string, Exception?> ModelBinderUsed = LoggerMessage.Define<string, string, string>(
        LogLevel.Debug,
        new EventId(TraceEventIdentifiers.ModelBinderUsedTrace.Value, nameof(TraceMessageModelBinderUsed)),
        "Parameter {modelName} of type {type} bound using ModelBinder \"{modelBinder}\""
    );

    private static readonly Action<ILogger, long, Exception?> ProfileMessageTrace = LoggerMessage.Define<long>(
        LogLevel.Information,
        new EventId(TraceEventIdentifiers.ProfileMessagingTrace.Value, nameof(TraceMessageProfiling)),
        PipelineBehaviour + " Request took {milliseconds} milliseconds"
    );

    private static readonly Action<ILogger, Exception?> ValidMessageTrace = LoggerMessage.Define(
    LogLevel.Debug,
    new EventId(TraceEventIdentifiers.ValidMessageTrace.Value, nameof(TraceMessageValidationPassed)),
    PipelineBehaviour + " Message is valid"
    );

    private const string PipelineBehaviour = "Pipeline Behaviour: ";


    /// <summary>
    /// Logs out a profile from a completed operation using the provided <paramref name="milliseconds"/>
    /// </summary>
    /// <param name="logger"><inheritdoc cref="ILogger"/></param>
    /// <param name="milliseconds">The total elapsed milliseconds an operation took</param>
    public static void TraceMessageProfiling(this ILogger logger, long milliseconds)
    {
        ProfileMessageTrace(logger, milliseconds, null);
    }

    /// <summary>
    /// Logs out a message indicating when a validation failure occurs in process
    /// </summary>
    /// <param name="logger"><inheritdoc cref="ILogger"/></param>
    /// <param name="message">The provided failure message</param>
    /// <param name="user">The user this occurred under</param>
    public static void TraceMessageValidationFailed(this ILogger logger, string message, string user) => InvalidMessageTrace(logger, message, user, null);

    /// <summary>
    /// Logs out a message before a validation step
    /// </summary>
    /// <param name="logger"><inheritdoc cref="ILogger"/></param>
    public static void TraceBeforeValidatingMessage(this ILogger logger) => BeforeValidatingMessageTrace(logger, null);


    /// <summary>
    /// Logs out a message indicating the type of model binder used
    /// </summary>
    /// <param name="logger"><inheritdoc cref="ILogger"/></param>
    /// <param name="parameter"></param>
    /// <param name="type">The underlying type used for the model</param>
    /// <param name="modelBinder">The model binder's name</param>
    public static void TraceMessageModelBinderUsed(this ILogger logger, string parameter, string type,
        string modelBinder) => ModelBinderUsed(logger, parameter, type, modelBinder, null);

    /// <summary>
    /// Logs out a message indicating that validation has passed
    /// </summary>
    /// <param name="logger"><inheritdoc cref="ILogger"/></param>
    public static void TraceMessageValidationPassed(this ILogger logger) => ValidMessageTrace(logger, null);
}

