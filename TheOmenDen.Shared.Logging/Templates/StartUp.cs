namespace TheOmenDen.Shared.Logging.Templates;
/// <summary>
/// A set of application constants for registration of services via assemblies
/// </summary>
public static class StartUp
{
    /// <summary>
    /// For referencing items in the domain assembly
    /// </summary>
    /// <value>
    /// DomainAssembly
    /// </value>
    public const string Domain = "DomainAssembly";
    /// <summary>
    /// For referencing items in the executing assembly
    /// </summary>
    /// <value>
    /// ExecutingAssembly
    /// </value>
    public const string Executing = "ExecutingAssembly";

    /// <summary>
    /// Indicating a starting major version for events
    /// </summary>
    /// <value>
    /// 1
    /// </value>
    public const int MajorVersion1 = 1;
    /// <summary>
    /// Indicating a starting minor version for events
    /// </summary>
    /// <value>
    /// 0
    /// </value>
    public const int MinorVersion0 = 0;
}
