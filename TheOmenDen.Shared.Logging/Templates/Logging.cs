namespace TheOmenDen.Shared.Logging.Templates;

/// <summary>
/// A set of LogContexts to determine where the logging statement originated
/// </summary>
public static class Logging
{
    public sealed class LogContexts
    {
        /// <summary>
        /// The type of request that was issued
        /// </summary>
        /// <value>RequestType</value>
        public const string RequestTypeProperty = "RequestType";

        /// <summary>
        /// The route we took
        /// </summary>
        /// <value>From Route</value>
        public const string FromRoute = "From Route";
    }
}