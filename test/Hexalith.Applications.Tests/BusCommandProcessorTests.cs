// <copyright file="BusCommandProcessorTests.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests;

using System;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.Applications;
using Hexalith.Applications.Commands;
using Hexalith.Applications.Tests.Helpers;
using Hexalith.Commons.Metadatas;

using Moq;

using Shouldly;

/// <summary>
/// Tests for <see cref="BusCommandProcessor"/>.
/// </summary>
public class BusCommandProcessorTests
{
    /// <summary>
    /// Ensures commands are forwarded to the underlying bus.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task SubmitAsyncShouldPublishCommand()
    {
        Mock<ICommandBus> busMock = new();
        BusCommandProcessor processor = new(busMock.Object, TimeProvider.System);
        object command = new();
        Metadata metadata = TestFixtures.CreateMetadata();

        await processor.SubmitAsync(command, metadata, CancellationToken.None).ConfigureAwait(true);

        busMock.Verify(b => b.PublishAsync(command, metadata, It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Ensures null commands are rejected.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task SubmitAsyncShouldThrowWhenCommandIsNull()
    {
        Mock<ICommandBus> busMock = new();
        BusCommandProcessor processor = new(busMock.Object, TimeProvider.System);
        Metadata metadata = TestFixtures.CreateMetadata();

        _ = await Should.ThrowAsync<ArgumentNullException>(() => processor.SubmitAsync(null!, metadata, CancellationToken.None)).ConfigureAwait(true);
    }
}