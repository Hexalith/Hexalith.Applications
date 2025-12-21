// <copyright file="UnitTest1.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.MyNewPackage.Tests;

using Shouldly;

/// <summary>
/// Initial unit tests for Hexalith.MyNewPackage.
/// </summary>
public static class UnitTest1
{
    /// <summary>
    /// Example test to verify test infrastructure is working.
    /// </summary>
    [Fact]
    public static void ExampleTestShouldPass()
    {
        // Arrange
        const int expected = 42;

        // Act
        const int actual = 42;

        // Assert
        actual.ShouldBe(expected);
    }
}