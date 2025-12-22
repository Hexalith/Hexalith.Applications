// <copyright file="TestAggregate.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Applications.Tests.Helpers;

using System.Collections.Generic;

using Hexalith.Domains;
using Hexalith.Domains.Results;

/// <summary>
/// Simple test aggregate for unit tests.
/// </summary>
/// <param name="aggregateId">Aggregate identifier.</param>
/// <param name="aggregateName">Aggregate name.</param>
/// <param name="initialized">Whether the aggregate is initialized.</param>
/// <param name="failOnApply">Whether Apply should fail.</param>
/// <param name="failureReason">Optional failure reason.</param>
/// <param name="messages">Messages returned on apply.</param>
internal sealed class TestAggregate(
    string aggregateId,
    string aggregateName,
    bool initialized,
    bool failOnApply,
    string? failureReason,
    IEnumerable<object>? messages) : IDomainAggregate
{
    /// <inheritdoc/>
    public string DomainId { get; } = aggregateId;

    /// <inheritdoc/>
    public string DomainName { get; } = aggregateName;

    private bool FailOnApplyFlag { get; } = failOnApply;

    private string? FailureReasonValue { get; } = failureReason;

    private bool IsInitializedFlag { get; } = initialized;

    private IEnumerable<object> MessagesValue { get; } = messages ?? [];

    /// <inheritdoc/>
    public ApplyResult Apply(object domainEvent) =>
        new(
            this,
            FailOnApplyFlag ? MessagesValue : [domainEvent],
            FailOnApplyFlag,
            FailureReasonValue ?? string.Empty);

    /// <inheritdoc/>
    public bool IsInitialized() => IsInitializedFlag;
}