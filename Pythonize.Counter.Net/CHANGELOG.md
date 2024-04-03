### Pythonize.Counter.Net CHANGELOG

## v1.0.4
- [x] Improved performance when initializing Counter class

  | Method                                   | Mean         | Error      | StdDev     | Median      |
  |----------------------------------------- |-------------:|-----------:|-----------:|------------:|
  | CounterWithoutMarshall_Benchmark_1_000   |     57.18 us |   1.137 us |   2.348 us |    57.53 us |
  | CounterWithMarshall_Benchmark_1_000      |     44.79 us |   0.910 us |   2.682 us |    45.64 us |
  | CounterWithoutMarshall_Benchmark_100_000 | 10,158.76 us | 271.025 us | 786.293 us | 9,988.83 us |
  | CounterWithMarshall_Benchmark_100_000    |  8,377.21 us | 259.058 us | 739.107 us | 8,303.95 us |

  > Was CounterWithoutMarshall

  > Is CounterWithMarshall
