// <copyright file="DomainEventCancelledTests.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests;

using Hexalith.Applications.Commands;
using Hexalith.Applications.States;
using Hexalith.Applications.Tests.Helpers;
using Hexalith.Commons.Metadatas;

using Shouldly;

/// <summary>
/// Tests for <see cref="DomainEventCancelled"/> metadata mapping.
/// </summary>
public class DomainEventCancelledTests
{
    /// <summary>
    /// Ensures aggregate identifiers reflect inner message metadata.
    /// </summary>
    [Fact]
    public void AggregatePropertiesShouldMatchMetadata()
    {
        Metadata metadata = TestFixtures.CreateMetadata(aggregateId: "agg-42", aggregateName: "SampleAggregate");
        MessageState state = new("payload", metadata);

        DomainEventCancelled cancelled = new("reason", state);

        cancelled.AggregateId.ShouldBe("agg-42");
        cancelled.AggregateName.ShouldBe("SampleAggregate");
    }
}
