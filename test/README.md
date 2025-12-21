# Test Projects

This directory contains test projects following the Hexalith testing conventions.

## Structure

Each project must have a corresponding test project with the naming convention:

- Format: `{ProjectName}.Tests`
- Location: `./test/{ProjectName}.Tests`

## Test Projects

- **Hexalith.MyNewPackage.Tests**: Unit tests for the main package

## Testing Framework

- **Framework**: xUnit
- **Assertion Library**: Shouldly
- **Target Framework**: .NET 10

## Running Tests

Run all tests from the solution root:

```powershell
dotnet test
```

Run tests for a specific project:

```powershell
dotnet test ./test/Hexalith.MyNewPackage.Tests/Hexalith.MyNewPackage.Tests.csproj
```

Run tests with detailed output:

```powershell
dotnet test --logger "console;verbosity=detailed"
```

## Writing Tests

Follow these conventions when writing tests:

- Use descriptive test method names
- Follow the Arrange-Act-Assert pattern
- Use Shouldly for assertions
- Include XML documentation for test classes and methods
