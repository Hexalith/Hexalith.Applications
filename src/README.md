# Source Code

This directory contains all source code for the Hexalith.MyNewPackage solution.

## Structure

| Directory | Description |
|-----------|-------------|
| [libraries](./libraries/README.md) | NuGet package projects |
| [examples](./examples/README.md) | Example implementations demonstrating usage |

## Projects

### Libraries

- **Hexalith.MyNewPackage** - Main implementation package
- **Hexalith.MyNewPackage.Abstractions** - Interface definitions and contracts

### Examples

- **Hexalith.MyNewPackage.Example** - Console application demonstrating basic usage

## Building

Build all projects from the solution root:

```powershell
dotnet build
```

Build only source projects:

```powershell
dotnet build ./src
```
