// <copyright file="DependencyInjectionDomainCommandDispatcherTests.cs" company="ITANEO">
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
using Hexalith.Domains;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;

using Shouldly;

/// <summary>
/// Tests for <see cref="DependencyInjectionDomainCommandDispatcher"/>.
/// </summary>
public class DependencyInjectionDomainCommandDispatcherTests
{
    /// <summary>
    /// Ensures registered handlers are invoked via DI resolution.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task DoAsyncShouldCallRegisteredHandler()
    {
        ServiceCollection services = new();
        RecordingCommandHandler handler = new();
        _ = services.AddSingleton<IDomainCommandHandler<SampleCommand>>(handler);
        IServiceProvider provider = services.BuildServiceProvider();
        DependencyInjectionDomainCommandDispatcher dispatcher = new(provider, NullLogger<DependencyInjectionDomainCommandDispatcher>.Instance);
        SampleCommand command = new("payload");
        Metadata metadata = TestFixtures.CreateMetadata();
        IDomainAggregate aggregate = TestFixtures.CreateAggregate();

        ExecuteCommandResult result = await dispatcher.DoAsync(command, metadata, aggregate, CancellationToken.None).ConfigureAwait(true);

        handler.LastCommand.ShouldBe(command);
        handler.ReceivedMetadata.ShouldBe(metadata);
        result.Aggregate.ShouldBe(aggregate);
    }

    /// <summary>
    /// Ensures missing handlers surface as errors.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    [Fact]
    public async Task DoAsyncShouldThrowWhenHandlerNotFound()
    {
        IServiceProvider provider = new ServiceCollection().BuildServiceProvider();
        DependencyInjectionDomainCommandDispatcher dispatcher = new(provider, NullLogger<DependencyInjectionDomainCommandDispatcher>.Instance);
        SampleCommand command = new("missing");
        Metadata metadata = TestFixtures.CreateMetadata();
        IDomainAggregate aggregate = TestFixtures.CreateAggregate();

        _ = await Should.ThrowAsync<InvalidOperationException>(() => dispatcher.DoAsync(command, metadata, aggregate, CancellationToken.None)).ConfigureAwait(true);
    }

    private sealed class RecordingCommandHandler : DomainCommandHandler<SampleCommand>
    {
        public RecordingCommandHandler()
            : base(TimeProvider.System, NullLogger<DomainCommandHandler<SampleCommand>>.Instance)
        {
        }

        public SampleCommand? LastCommand { get; private set; }

        public Metadata? ReceivedMetadata { get; private set; }

        public override Task<ExecuteCommandResult> DoAsync(SampleCommand command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
        {
            LastCommand = command;
            ReceivedMetadata = metadata;
            return Task.FromResult(new ExecuteCommandResult(aggregate ?? TestFixtures.CreateAggregate(), [command], [], false));
        }
    }

    private sealed record SampleCommand(string Value);
}
