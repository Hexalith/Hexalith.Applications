# Hexalith.MyNewPackage.Abstractions

## Overview

This package contains the interface definitions and abstractions for Hexalith.MyNewPackage. It defines contracts that are implemented by the main `Hexalith.MyNewPackage` package.

## Installation

```powershell
dotnet add package Hexalith.MyNewPackage.Abstractions
```

Or via NuGet Package Manager:

```powershell
Install-Package Hexalith.MyNewPackage.Abstractions
```

## Prerequisites

- .NET 10 or later

## Usage

Reference this package when you only need the interface definitions without the concrete implementations:

```csharp
using Hexalith.MyNewPackage;

public class MyService
{
    private readonly IDummyClass _dummy;

    public MyService(IDummyClass dummy)
    {
        _dummy = dummy;
    }

    public void DoSomething()
    {
        Console.WriteLine(_dummy.SampleValue);
    }
}
```

## Interfaces

- `IDummyClass` - Sample interface demonstrating the abstractions pattern

## Why Abstractions?

Separating abstractions into their own package allows:

- **Loose coupling**: Depend only on interfaces, not implementations
- **Dependency injection**: Easily swap implementations
- **Testing**: Mock interfaces for unit testing
- **Reduced dependencies**: Reference only what you need

## Building

```powershell
dotnet build
```

## License

This project is licensed under the MIT License - see the [LICENSE](../../../LICENSE) file for details.
