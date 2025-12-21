# NuGet Package Libraries

This directory contains the NuGet package projects for Hexalith.Applications.

## Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| [Hexalith.Applications](./Hexalith.Applications/README.md) | Main implementation package | [![NuGet](https://img.shields.io/nuget/v/Hexalith.Applications.svg)](https://www.nuget.org/packages/Hexalith.Applications) |
| [Hexalith.Applications.Abstractions](./Hexalith.Applications.Abstractions/README.md) | Interface definitions | [![NuGet](https://img.shields.io/nuget/v/Hexalith.Applications.Abstractions.svg)](https://www.nuget.org/packages/Hexalith.Applications.Abstractions) |

## Package Architecture

```
Hexalith.Applications.Abstractions  (interfaces)
         ▲
         │
Hexalith.Applications               (implementations)
```

The abstractions package contains only interfaces and contracts. The main package provides concrete implementations and depends on the abstractions.

## Building Packages

Build all packages:

```powershell
dotnet build ./src/libraries
```

Create NuGet packages:

```powershell
dotnet pack ./src/libraries
```

## Adding New Libraries

1. Create a new project in this directory
2. Follow the naming convention: `Hexalith.Applications.{Feature}`
3. Add a README.md file documenting the package
4. Update this README to include the new package
