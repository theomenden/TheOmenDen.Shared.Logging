namespace TheOmenDen.Shared.Logging.Templates;

/// <summary>
/// A set of templates for logging errors more effectively
/// </summary>
public static class Errors
{
    /// <value>
    /// A template for creating an unhandled error dialog
    /// </value>
    public const string UnhandledErrorDebug = @"An unhandled error occurred. {0}";

    /// <value>
    /// A template for reporting unhandled errors
    /// </value>
    public const string UnhandledError = @"An error has occurred in the application" +
                                         "Please contact our support team if the problem persists, citing the correlation id of the Error Message. Correlation Id: {0}";
    /// <value>
    /// A template for reporting validation errors
    /// </value>
    public const string ValidationFailure = @"Validation errors have occurred on the server.";
}
