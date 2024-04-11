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

## How-to-use
>obviously like collections.Counter

A Counter is a Dictionary for couting objects. Keys are elements and Values are counts.

### Counter<T> Class

The `Counter<T>` class is a generic class that counts the occurrences of items in an enumerable or span of items.
Initializes a new instance of the `Counter<T>` class with the specified enumerable of items.

  ```csharp
var value = "abacaba";
var counter = new Counter<char>(value);
  ```

#### Dictionary<T, int> Get()

Gets the counts of items.

```csharp
var counter = new Counter<string>(new[] { "apple", "banana", "apple", "orange", "banana", "banana" });
var counts = counter.Get();
// Output:
// { ["apple": 2], ["banana": 3], ["orange": 1] }
```

#### int Total()

Calculate the sum of the counts.

```csharp
var counter = new Counter<string>(new[] { "apple", "banana", "apple", "orange", "banana", "banana" });
var total = counter.Total();
// Output:
// 6
```

#### IEnumerable<T> Elements()

Returns an enumerable of elements based on the counts of items.

```csharp
var counter = new Counter<string>(new[] { "apple", "banana", "apple", "orange", "banana", "banana" });
var elements = counter.Elements();
// Output:
// { "apple", "banana", "apple", "orange", "banana", "banana" }
```

#### IEnumerable<KeyValuePair<T, int>> MostCommon(int count)

Returns the specified number of most common elements along with their counts from the dictionary.

```csharp
var counter = new Counter<string>(new[] { "apple", "banana", "apple", "orange", "banana", "banana" });
var elements = counter.MostCommon(2);
// Output:
// { ("banana": 3), ("apple": 2) }
```

### Exceptions

- `ArgumentNullException`: thrown when the `value` parameter is null.
- `ArgumentOutOfRangeException`: thrown when the `count` parameter is less than 1.

## Changelog
See all changes with versions [Here](https://github.com/Lukeuke/Pythonize.Counter.Net/blob/main/CHANGELOG.md)

## License
This library is licensed under the MIT License. See the [LICENSE](https://github.com/Lukeuke/Pythonize.Counter.Net/blob/main/LICENSE) file for details.
