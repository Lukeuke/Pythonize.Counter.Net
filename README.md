# Pythonize.Counter.Net
![Tests](https://github.com/Lukeuke/Pythonize.Counter.Net/actions/workflows/dotnet.yml/badge.svg)
![Build](https://github.com/Lukeuke/Pythonize.Counter.Net/actions/workflows/build-only.yml/badge.svg)

## Description

Pythonize.Counter.Net is a C# library that provides a Python-like Counter

## Installation

To use Pythonize.Counter.Net in your project, you can install it via NuGet Package Manager:

```bash
Install-Package Pythonize.Counter.Net
```

## Usage
Example:
```csharp
var value = "abacaba";
var counter = new Counter<char>(value);
var counts = counter.Get();
```

## License
This library is licensed under the MIT License. See the <a href="https://github.com/Lukeuke/Pythonize.Counter.Net/blob/main/LICENSE"> LICENSE </a> file for details.
