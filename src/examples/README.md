# Example Projects

This directory contains example projects demonstrating how to use the Hexalith.Applications libraries.

## Projects

### Hexalith.Applications.Example

A simple console application that demonstrates basic usage of the package.

**Location**: `./Hexalith.Applications.Example/`

**Run the example**:

```powershell
dotnet run --project ./src/examples/Hexalith.Applications.Example/Hexalith.Applications.Example.csproj
```

Or from the example directory:

```powershell
cd src/examples/Hexalith.Applications.Example
dotnet run
```

## Purpose

These examples serve as:

- **Quick start guides** - See working code immediately
- **Reference implementations** - Understand how to integrate the library
- **Testing ground** - Experiment with features

## Adding New Examples

1. Create a new project in this directory
2. Follow the naming convention: `Hexalith.Applications.Example.{Feature}`
3. Reference the library packages from `src/libraries`
4. Update this README to document the new example
