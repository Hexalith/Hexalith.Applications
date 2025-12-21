// <copyright file="MemoryCommandBusTests.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests;

using System;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Applications;
using Hexalith.Applications.Tests.Helpers;
using Hexalith.Commons.Metadatas;

using Shouldly;

/// <summary>
/// Tests for <see cref="MemoryCommandBus"/>.
/// </summary>
public class MemoryCommandBusTests
{
    /// <summary>
    /// Ensures published messages are stored in memory.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task PublishAsyncShouldStoreMessage()
    {
        MemoryCommandBus bus = new();
        object command = new();
        Metadata metadata = TestFixtures.CreateMetadata();

        await bus.PublishAsync(command, metadata, CancellationToken.None).ConfigureAwait(true);

        (object Message, Metadata Metadata) entry = bus.MessageStream.ShouldHaveSingleItem();
        entry.Message.ShouldBe(command);
        entry.Metadata.ShouldBe(metadata);
    }

    /// <summary>
    /// Ensures null messages are rejected.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task PublishAsyncShouldThrowWhenMessageIsNull()
    {
        MemoryCommandBus bus = new();
        Metadata metadata = TestFixtures.CreateMetadata();

        _ = await Should.ThrowAsync<ArgumentNullException>(() => bus.PublishAsync(null!, metadata, CancellationToken.None)).ConfigureAwait(true);
    }
}
