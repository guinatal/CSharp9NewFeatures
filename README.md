# CSharp9NewFeatures

A simple C# project with some examples of what's new in C# 9.0

- Framework .NET 6
- NuGet Dependencies: `BenchmarkDotNet 0.13.0` and `BenchmarkDotNet.Annotations 0.13.0`
- What's new in C# 9.0: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9

## Examples
- Record types
- Init only setters
- Top-level statements
- Pattern matching enhancements
- Performance and interop
  - Native sized integers
  - Function pointers
  - Suppress emitting localsinit flag `Benchmark`
- `TODO:` Fit and finish features
- `TODO:` Support for code generators

## Benchmark
- Release Mode
- Start Without Debugging (Ctrl + F5) in Visual Studio

In order to benchmark `Suppress emitting localsinit flag` press Y + Enter.

![image](https://user-images.githubusercontent.com/7348110/124382341-d62b7000-dcbe-11eb-807c-01425cd98ad5.png)

### Result

|         Method | Size |      Mean |     Error |    StdDev |
|--------------- |----- |----------:|----------:|----------:|
|     InitLocals |  512 | 14.449 ns | 0.3089 ns | 0.2889 ns |
| SkipInitLocals |  512 |  1.437 ns | 0.0378 ns | 0.0354 ns |
|     InitLocals | 1024 | 28.801 ns | 0.2666 ns | 0.2494 ns |
| SkipInitLocals | 1024 |  1.440 ns | 0.0341 ns | 0.0319 ns |

## Contribute
Contributions are welcome.
