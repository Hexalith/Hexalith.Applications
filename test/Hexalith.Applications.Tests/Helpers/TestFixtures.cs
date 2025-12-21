// <copyright file="TestFixtures.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests.Helpers;

using System;
using System.Collections.Generic;

using Hexalith.Commons.Metadatas;

/// <summary>
/// Provides helper factories for test data.
/// </summary>
internal static class TestFixtures
{
    /// <summary>
    /// Creates metadata for tests.
    /// </summary>
    /// <param name="aggregateId">Aggregate identifier.</param>
    /// <param name="aggregateName">Aggregate name.</param>
    /// <param name="messageName">Message name.</param>
    /// <param name="messageVersion">Message version.</param>
    /// <returns>A populated <see cref="Metadata"/> instance.</returns>
    public static Metadata CreateMetadata(
        string aggregateId = "aggregate-1",
        string aggregateName = "TestAggregate",
        string messageName = "TestCommand",
        int messageVersion = 1)
    {
        DomainMetadata domain = new(aggregateId, aggregateName);
        MessageMetadata message = new(
            Guid.NewGuid().ToString("N"),
            messageName,
            messageVersion,
            domain,
            DateTimeOffset.UtcNow);
        ContextMetadata context = new(
            Guid.NewGuid().ToString("N"),
            "user-1",
            "partition-1",
            DateTimeOffset.UtcNow,
            TimeSpan.FromMinutes(1),
            0,
            string.Empty,
            Guid.NewGuid().ToString("N"),
            []);
        return new Metadata(message, context);
    }

    /// <summary>
    /// Creates a test aggregate instance.
    /// </summary>
    /// <param name="aggregateId">Aggregate identifier.</param>
    /// <param name="aggregateName">Aggregate name.</param>
    /// <param name="initialized">Value indicating whether the aggregate is initialized.</param>
    /// <param name="failOnApply">Indicates whether Apply should fail.</param>
    /// <param name="failureReason">Optional apply failure reason.</param>
    /// <param name="messages">Optional messages to return from Apply.</param>
    /// <returns>A configured <see cref="TestAggregate"/>.</returns>
    public static TestAggregate CreateAggregate(
        string aggregateId = "aggregate-1",
        string aggregateName = "TestAggregate",
        bool initialized = true,
        bool failOnApply = false,
        string? failureReason = null,
        IEnumerable<object>? messages = null) =>
        new(aggregateId, aggregateName, initialized, failOnApply, failureReason, messages);
}
