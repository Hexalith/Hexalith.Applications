# NuGet Package Libraries

This directory contains the NuGet package projects for Hexalith.MyNewPackage.

## Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| [Hexalith.MyNewPackage](./Hexalith.MyNewPackage/README.md) | Main implementation package | [![NuGet](https://img.shields.io/nuget/v/Hexalith.MyNewPackage.svg)](https://www.nuget.org/packages/Hexalith.MyNewPackage) |
| [Hexalith.MyNewPackage.Abstractions](./Hexalith.MyNewPackage.Abstractions/README.md) | Interface definitions | [![NuGet](https://img.shields.io/nuget/v/Hexalith.MyNewPackage.Abstractions.svg)](https://www.nuget.org/packages/Hexalith.MyNewPackage.Abstractions) |

## Package Architecture

```
Hexalith.MyNewPackage.Abstractions  (interfaces)
         ▲
         │
Hexalith.MyNewPackage               (implementations)
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
2. Follow the naming convention: `Hexalith.MyNewPackage.{Feature}`
3. Add a README.md file documenting the package
4. Update this README to include the new package
