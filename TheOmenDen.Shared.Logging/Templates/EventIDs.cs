namespace TheOmenDen.Shared.Logging.Templates;

/// <summary>
/// A set of defined ids for logging events that can occur throughout the application
/// </summary>
public static class EventIDs
{
    /// <summary>
    /// Indicates a logged App thrown exception event
    /// </summary>
    /// <value>
    /// <see cref="EventIdIdentifier.AppThrown"/>
    /// </value>
    public static readonly EventId EventIdAppThrown = new(EventIdIdentifier.AppThrown.Value, EventIdIdentifier.AppThrown.ToString());
    /// <summary>
    /// Indicates an event that occurred within an <see cref="HttpClient"/> and was logged out
    /// </summary>
    /// <value>
    /// <see cref="EventIdIdentifier.HttpClient"/>
    /// </value>
    public static readonly EventId EventIdHttpClient = new(EventIdIdentifier.HttpClient.Value, EventIdIdentifier.HttpClient.ToString());
    /// <summary>
    /// Indicates an event that occurred within a pipeline and logged out
    /// </summary>
    /// <value>
    /// <see cref="EventIdIdentifier.PipelineThrown"/>
    /// </value>
    public static readonly EventId EventIdPipelineThrown = new(EventIdIdentifier.PipelineThrown.Value, EventIdIdentifier.PipelineThrown.ToString());
    /// <summary>
    /// Indicates an uncaught <see cref="Exception"/> that occurred during a particular action within the application
    /// </summary>
    /// <value>
    /// <see cref="EventIdIdentifier.UncaughtInAction"/>
    /// </value>
    public static readonly EventId EventIdUncaught = new(EventIdIdentifier.UncaughtInAction.Value, EventIdIdentifier.UncaughtInAction.ToString());
    /// <summary>
    /// Indicates an uncaught global level <see cref="Exception"/>
    /// </summary>
    /// <value>
    /// <see cref="EventIdIdentifier.UncaughtGlobal"/>
    /// </value>
    public static readonly EventId EventIdUncaughtGlobal = new(EventIdIdentifier.UncaughtGlobal.Value, EventIdIdentifier.UncaughtGlobal.ToString());
}