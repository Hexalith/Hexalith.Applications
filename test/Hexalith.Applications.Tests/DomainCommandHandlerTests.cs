// <copyright file="DomainCommandHandlerTests.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests;

using System.Threading;
using System.Threading.Tasks;

using Hexalith.Applications.Commands;
using Hexalith.Applications.Tests.Helpers;
using Hexalith.Commons.Metadatas;
using Hexalith.Domains;

using Shouldly;

/// <summary>
/// Tests for <see cref="DomainCommandHandler{TCommand}"/> validation behaviors.
/// </summary>
public class DomainCommandHandlerTests
{
    /// <summary>
    /// Ensures null aggregates raise a specific exception.
    /// </summary>
    [Fact]
    public void CheckAggregateIsValidShouldThrowWhenAggregateIsNull()
    {
        TestCommandHandler handler = new();
        Metadata metadata = TestFixtures.CreateMetadata();

        _ = Should.Throw<CommandHandlerAggregateNullException>(() => handler.Validate(null, metadata));
    }

    /// <summary>
    /// Ensures aggregate name mismatches are detected.
    /// </summary>
    [Fact]
    public void CheckAggregateIsValidShouldThrowWhenAggregateNameMismatch()
    {
        TestCommandHandler handler = new();
        Metadata metadata = TestFixtures.CreateMetadata(aggregateName: "expected");
        IDomainAggregate aggregate = TestFixtures.CreateAggregate(aggregateName: "actual");

        _ = Should.Throw<CommandHandlerAggregateNameMismatchException>(() => handler.Validate(aggregate, metadata));
    }

    /// <summary>
    /// Ensures aggregate identifier mismatches are detected.
    /// </summary>
    [Fact]
    public void CheckAggregateIsValidShouldThrowWhenAggregateIdMismatch()
    {
        TestCommandHandler handler = new();
        Metadata metadata = TestFixtures.CreateMetadata(aggregateId: "expected");
        IDomainAggregate aggregate = TestFixtures.CreateAggregate(aggregateId: "actual");

        _ = Should.Throw<CommandHandlerAggregateIdentifierMismatchException>(() => handler.Validate(aggregate, metadata));
    }

    /// <summary>
    /// Ensures valid aggregates are returned unchanged.
    /// </summary>
    [Fact]
    public void CheckAggregateIsValidShouldReturnAggregateWhenValid()
    {
        TestCommandHandler handler = new();
        IDomainAggregate aggregate = TestFixtures.CreateAggregate();
        Metadata metadata = TestFixtures.CreateMetadata();

        handler.Validate(aggregate, metadata).ShouldBe(aggregate);
    }

    /// <summary>
    /// Ensures default undo behavior throws <see cref="NotSupportedException"/>.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task UndoAsyncShouldThrowNotSupported()
    {
        TestCommandHandler handler = new();
        Metadata metadata = TestFixtures.CreateMetadata();
        IDomainAggregate aggregate = TestFixtures.CreateAggregate();

        _ = await Should.ThrowAsync<NotSupportedException>(() => handler.UndoAsync("cmd", metadata, aggregate, CancellationToken.None)).ConfigureAwait(true);
    }
}
