# TheOmenDen Shared Logging

### This library contains a basic logging implementation and some simple extensions that can be used in addition to your normal logging providers.

- _1st note: this library depends on [The Omen Den Shared Library](https://github.com/theomenden/TheOmenDen.Shared)_. 

- _2nd note, this library is not affiliated with the fine folks at Serilog, however it does define an enricher and extensions for Serilog consumers. Credit to [Serilog](https://github.com/serilog/serilog)_

- _3rd note, this library makes use of MurmurHash which can be found here: [MurmurHash](https://github.com/jitbit/MurmurHash.net)_

### We hope to accomplish the following things within the library, and will continue to provide maintenance and a plan for future improvements.

## 1. Templates
  - `Errors` - Custom _constant string_ error message templates.
    - Allows for custom error messages to be displayed and logged out more efficiently.
  - `EventIds` - Our custom extensions on `Microsoft.Extensions.Logging.EventId` struct.
    - Allows for more accurate tracing of events and where they occurred in an application. 
  - `Logging` - Provides basic _constant string_ logging messaging templates.
    - This enables you to list Request Pathing, and Logging context Pathing with these templates.
  - `StartUp` - Provides basic _constant string_ templates for bootstrapping an application.
  
## 2. Extensions
- `LoggerExtensions`
  - Provides extensions on the `Microsoft.Extensions.Logging.ILogger` interface
    - `TraceMessageProfiling`
      - Allows for the logging of milliseconds an operation within the application took to finish.
    - `TraceMessageValidationFailed`
      - Allows for the logging of validation failures.
    - `TraceBeforeValidatingMessage`
      - Allows for the logging before a validation event takes place.
    - `TraceMessageModelBinderUsed`
      - Allows the logging of a Model binder operation that was used in the process of validation.
    - `TraceMessageValidationPassed`
      - Logs out a successful message when a validation event is successful.

## 3. Serilog
- `EventTypeEnricher`
  - A naive implementation for enriching a logging context with a hashed Id.
- `RequestLoggingConfigurer`
  - EnrichFromRequest
    - Allows for the `Serilog.IDiagnosticContext` to log out properties from a provided `Microsoft.AspNetCire.Http.HttpContext`
- `EnvironmentLoggerConfigurationExtensions` 
  - Allows for registering the `EventTypeEnricher` using the `Enrich().WithEventType()` syntax in your Serilog logger configuration.
## 4. Http Message Logging
- `MetaData`
  - A simple structure meant to provide basic metadata information for Http Request and Responses.
  - Provides a way to see the information logged in a more structured form.
- `DelegatingLogHandler`
  - A `DelegatingHandler` implementation that allows for logging of specific properties in an `HttpMessage`.
  - Comes with a set of of extensions in `HttpMessageHandlerRegistrationExtensions.cs` to allow you to register the handler itself as a `Transient` service, then onto HttpClients. 
    - Can also be configured to register on _ALL_ clients defined in the same service collection.
## 5. Options
- `ApiExceptionOptions` and `OptionsDelegates`
  - A simple container for actions that allow for log level adjustments and exception detail customizations
  - These can be configured within middleware in your .NET applications.
    - `AddResponseDetails`
      - Allows one to define how specific exceptions are logged out to a Payload's message.
      - Meant to be used in conjunction with `OptionsDelegates.UpdateApiErrorResponse`
    - `DetermineLogLevel`
      - A way to determine how certain exceptions are reported in the logs
      - Meant to be combined with `OptionsDelegates.DetermineLogLevel` - which allows for certain exceptions to be reported with a `LogLevel.Critical` instead of `LogLevel.Error`