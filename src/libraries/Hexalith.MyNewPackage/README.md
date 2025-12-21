# Hexalith.MyNewPackage

## Overview

This is the main implementation package for Hexalith.MyNewPackage. It provides concrete implementations of the interfaces defined in `Hexalith.MyNewPackage.Abstractions`.

## Installation

```powershell
dotnet add package Hexalith.MyNewPackage
```

Or via NuGet Package Manager:

```powershell
Install-Package Hexalith.MyNewPackage
```

## Prerequisites

- .NET 10 or later

## Usage

```csharp
using Hexalith.MyNewPackage;

// Create an instance of DummyClass
var dummy = new DummyClass("Hello, World!");
Console.WriteLine(dummy.SampleValue);
```

## Project Structure

- `DummyClass.cs` - Sample implementation demonstrating the package structure

## Dependencies

- `Hexalith.MyNewPackage.Abstractions` - Interface definitions

## Building

```powershell
dotnet build
```

## Contributing

Contributions are welcome. Please ensure your code adheres to the project standards and is covered by tests.

## License

This project is licensed under the MIT License - see the [LICENSE](../../../LICENSE) file for details.
