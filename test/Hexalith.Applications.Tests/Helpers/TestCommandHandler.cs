// <copyright file="TestCommandHandler.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests.Helpers;

using System.Threading;
using System.Threading.Tasks;

using Hexalith.Applications.Commands;
using Hexalith.Commons.Metadatas;
using Hexalith.Domains;

using Microsoft.Extensions.Logging.Abstractions;

/// <summary>
/// Concrete test command handler exposing aggregate validation for tests.
/// </summary>
internal sealed class TestCommandHandler : DomainCommandHandler<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestCommandHandler"/> class.
    /// </summary>
    public TestCommandHandler()
        : base(TimeProvider.System, NullLogger<DomainCommandHandler<string>>.Instance)
    {
    }

    /// <summary>
    /// Validates aggregate against metadata.
    /// </summary>
    /// <param name="aggregate">Aggregate to validate.</param>
    /// <param name="metadata">Associated metadata.</param>
    /// <returns>The validated aggregate.</returns>
    public IDomainAggregate Validate(IDomainAggregate? aggregate, Metadata metadata) =>
        CheckAggregateIsValid<IDomainAggregate>(aggregate, metadata);

    /// <inheritdoc/>
    public override Task<ExecuteCommandResult> DoAsync(string command, Metadata metadata, IDomainAggregate? aggregate, CancellationToken cancellationToken)
    {
        IDomainAggregate validated = CheckAggregateIsValid<IDomainAggregate>(aggregate, metadata);
        return Task.FromResult(new ExecuteCommandResult(validated, [command], [], false));
    }
}
