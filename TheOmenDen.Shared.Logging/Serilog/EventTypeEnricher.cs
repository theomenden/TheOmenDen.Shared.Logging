﻿using Murmur;

namespace TheOmenDen.Shared.Logging.Serilog;

/// <summary>
/// Provides a method of enriching a <see cref="Serilog"/> implementation with a provided <see cref="LogEvent"/>
/// </summary>
public class EventTypeEnricher : ILogEventEnricher
{
    /// <summary>
    /// <inheritdoc cref="ILogEventEnricher.Enrich(LogEvent, ILogEventPropertyFactory)"/>
    /// </summary>
    /// <param name="logEvent"></param>
    /// <param name="propertyFactory"></param>
    /// <exception cref="ArgumentNullException"><paramref name="buffer" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 3, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var murmur = MurmurHash.Create32();

        var bytes = Encoding.UTF8.GetBytes(logEvent.MessageTemplate.Text);

        var hash = murmur.ComputeHash(bytes);

        var numericHash = BitConverter.ToUInt32(hash, 0);

        var eventId = propertyFactory.CreateProperty("EventType", numericHash);

        logEvent.AddPropertyIfAbsent(eventId);
    }
}
