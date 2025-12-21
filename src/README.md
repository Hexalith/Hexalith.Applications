# Source Code

This directory contains all source code for the Hexalith.Applications solution.

## Structure

| Directory | Description |
|-----------|-------------|
| [libraries](./libraries/README.md) | NuGet package projects |
| [examples](./examples/README.md) | Example implementations demonstrating usage |

## Projects

### Libraries

- **Hexalith.Applications** - Main implementation package
- **Hexalith.Applications.Abstractions** - Interface definitions and contracts

### Examples

- **Hexalith.Applications.Example** - Console application demonstrating basic usage

## Building

Build all projects from the solution root:

```powershell
dotnet build
```

Build only source projects:

```powershell
dotnet build ./src
```
