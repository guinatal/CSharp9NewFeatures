using BenchmarkDotNet.Running;
using CSharpNewFeaturesConsoleApp.Benchmarks;
using CSharpNewFeaturesConsoleApp.Classes;
using CSharpNewFeaturesConsoleApp.Extensions;
using CSharpNewFeaturesConsoleApp.Records;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#region Main

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements">Top-level statements</see>
/// <summary>
/// Top-level statements
/// Top-level statements remove unnecessary ceremony from many applications.
/// Only one file in your application may use top-level statements. If the compiler finds top-level statements in multiple source files, it's an error.
/// It's also an error if you combine top-level statements with a declared program entry point method, typically a Main method.
/// In a sense, you can think that one file contains the statements that would normally be in the Main method of a Program class.
/// Azure Functions is an ideal use case for top-level statements.
/// </summary>

Console.WriteLine("Hello World!");

_ = args.Length; // accessing args normally (=

RecordTypes();

InitOnlySetters();

PatternMatchingEnhancements();

PerformanceAndInterop();

FitAndFinishFeatures();

#endregion

#region Record Types

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types">Record Types</see>
/// <summary>
/// Record Types
/// C# 9.0 introduces record types.
/// You use the record keyword to define a reference type that provides built-in functionality for encapsulating data.
/// While records can be mutable, they are primarily intended for supporting immutable data models.
/// </summary>
static void RecordTypes()
{
    Console.WriteLine("RecordTypes");

    // example 1 => immutable properties
    Desk desk1 = new("desk xyz", "blue");
    // desk1.Name = "desk xxx"; // => compilation error
    Console.WriteLine(desk1);

    // example 2 => immutable properties
    Airplane airplane1 = new()
    {
        Name = "Airplane1",
        Type = "boeing 747"
    };
    // airplane.Name = "Airplane2"; // => compilation error
    Console.WriteLine(airplane1);

    // example 3 => mutable properties
    Car car1 = new();
    car1.Name = "V40";
    car1.Brand = "Volvo";
    Console.WriteLine(car1);

    // example 4 => mutate immutable properties of a record instance
    // A with expression makes a new record instance that is a copy of an existing record instance, with specified properties and fields modified.
    Desk desk2 = desk1 with { Name = "desk xxx" };
    Console.WriteLine(desk2);

    // example 5 => inheritance
    // A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.
    Employee employee1 = new("Guilherme", "Mello", "Developer");
    Console.WriteLine(desk1);
}

#endregion

#region InitOnlySetters

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters">Init Only Setters</see>
/// <summary>
/// Init Only Setters
/// Init only setters provide consistent syntax to initialize members of an object.
/// Property initializers make it clear which value is setting which property.
/// The downside is that those properties must be settable.
/// Starting with C# 9.0, you can create init accessors instead of set accessors for properties and indexers.
/// Callers can use property initializer syntax to set these values in creation expressions, but those properties are readonly once construction has completed.
/// </summary>
static void InitOnlySetters()
{
    Console.WriteLine("InitOnlySetters");

    // Check 'Airplane' record
    // public string Name { get; init; }
    // public string Type { get; init; }
    Airplane airplane1 = new()
    {
        Name = "Airplane1",
        Type = "boeing 747"
    };
    // airplane.Name = "Airplane2"; // => compilation error
    Console.WriteLine(airplane1);
}

#endregion

#region PatternMatchingEnhancements

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements">Pattern matching enhancements</see>
/// <summary>
/// Pattern matching enhancements
/// Type patterns => match a variable is a type
/// Parenthesized patterns => enforce or emphasize the precedence of pattern combinations
/// Conjunctive and patterns => require both patterns to match
/// Disjunctive or patterns => require either pattern to match
/// Negated not patterns => require that a pattern doesn't match
/// Relational patterns => require the input be less than, greater than, less than or equal, or greater than or equal to a given constant.
/// </summary>
static void PatternMatchingEnhancements()
{
    Console.WriteLine("PatternMatchingEnhancements");

    char char1 = 'a';
    Console.WriteLine(char1.IsLetter());
    Console.WriteLine(char1.IsLetterOrSeparator());

    char char2 = '5';
    Console.WriteLine(char2.IsLetter());
    Console.WriteLine(char2.IsLetterOrSeparator());
}

#endregion

#region Performance and interop

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#performance-and-interop">Performance and interop</see>
/// <summary>
/// Performance and interop
/// Three new features improve support for native interop and low-level libraries that require high performance: 
/// native sized integers, function pointers, and omitting the localsinit flag.
/// Native sized integers, nint and nuint, are integer types.
/// They're expressed by the underlying types System.IntPtr and System.UIntPtr.
/// </summary>
static void PerformanceAndInterop()
{
    Console.WriteLine("PerformanceAndInterop");

    NativeSizedIntegers();

    FunctionPointers();

    SuppressingLocalsinit();
}

/// <summary>
/// Native sized integers
/// </summary>
static void NativeSizedIntegers()
{
    Console.WriteLine("NativeSizedIntegers");

    nint i = 1;
    nuint ui = 1;

    Console.WriteLine(i);
    Console.WriteLine(ui);

    IntPtr ii = (IntPtr)1;
    UIntPtr uii = (UIntPtr)1;

    Console.WriteLine(ii);
    Console.WriteLine(uii);

    int test1 = (int)i;
    long test2 = (long)ui;

    Console.WriteLine(test1);
    Console.WriteLine(test2);

    const nint n = int.MaxValue;
    const nuint nu = uint.MaxValue;

    Console.WriteLine(n);
    Console.WriteLine(nu);

    // Native integers can be marked const, but only when the compiler knows that the result won’t overflow on any architecture
    //const nint m = unchecked(n + 1); // => compilation error
    const nint m = unchecked(n + 0);

    Console.WriteLine(m);
}

/// <summary>
/// Function pointers
/// Function pointers provide an easy syntax to access the IL opcodes ldftn and calli.
/// You can declare function pointers using new delegate* syntax. A delegate* type is a pointer type.
/// Invoking the delegate* type uses calli, in contrast to a delegate that uses callvirt on the Invoke() method.
/// Syntactically, the invocations are identical. Function pointer invocation uses the managed calling convention.
/// You add the unmanaged keyword after the delegate* syntax to declare that you want the unmanaged calling convention.
/// Other calling conventions can be specified using attributes on the delegate* declaration.
/// </summary>
static unsafe void FunctionPointers()
{
    Console.WriteLine("FunctionPointers");

    delegate*<int, int> f = &Squared;

    Console.WriteLine(f(10));

    static int Squared(int a) => a * a;
}

/// <summary>
/// SkipLocalsInit Attribute
/// When performance is critical, it may be desirable to omit this zeroing. C# 9 supports that performance measure through the new SkipLocalsInit attribute.
/// This attribute can be applied at the method level, the class level, or even for the entire module:
/// For the entire project. [module: System.Runtime.CompilerServices.SkipLocalsInit]
/// or, for a  specific method. [SkipLocalsInit]
/// </summary>
static void SuppressingLocalsinit()
{
    Console.WriteLine("SuppressingLocalsinit");

    Console.WriteLine("Benchmark press Y else press any other key, and then press Enter");

    string executeBanchmark = Console.ReadLine();
    if (executeBanchmark.Equals("Y", StringComparison.OrdinalIgnoreCase))
    {
        var summary = BenchmarkRunner.Run<SkipLocalsInitBenchmark>();
    }
}

#endregion

#region Fit and finish features

/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#fit-and-finish-features">Fit and finish features</see>
/// <summary>
/// Fit and finish features
/// </summary>
static void FitAndFinishFeatures()
{
    Console.WriteLine("FitAndFinishFeatures");

    // Many of the other features help you write code more efficiently.
    // In C# 9.0, you can omit the type in a new expression when the created object's type is already known.
    Document document1 = new();

    // Target-typed new can also be used when you need to create a new object to pass as an argument to a method.
    Document document2 = new(new());

    // Another nice use for this feature is to combine it with init only properties to initialize a new object:
    Document document3 = new()
    {
        Name = "Document XYZ"
    };

    // A similar feature improves the target type resolution of conditional expressions.
    // With this change, the two expressions need not have an implicit conversion from one to the other,
    // but may both have implicit conversions to a target type.
    // You likely won't notice this change. What you will notice is that some conditional expressions that previously
    // required casts or wouldn't compile now just work.
    bool b = true;
    int? result = b ? 0 : null; // nullable value type

    // Starting in C# 9.0, you can add the static modifier to lambda expressions or anonymous methods.
    // Static lambda expressions are analogous to the static local functions: a static lambda or anonymous
    // method can't capture local variables or instance state. The static modifier prevents accidentally
    // capturing other variables.
    Func<double, double> square = static x => x * x;
    double squareResult = square(10);

    // Covariant return types provide flexibility for the return types of override methods.
    // An override method can return a type derived from the return type of the overridden base method.
    // This can be useful for records and for other types that support virtual clone or factory methods.
    Employee employee1 = new("Guilherme", "Mello", "Developer");
    employee1.GetPerson();

    // In addition, the foreach loop will recognize and use an extension method GetEnumerator that otherwise satisfies the foreach pattern.
    // This change means foreach is consistent with other pattern-based constructions such as the async pattern, and pattern-based deconstruction.
    // In practice, this change means you can add foreach support to any type. You should limit its use to when enumerating an object makes sense in your design.
    List<string> daysOfWeek = new() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    IEnumerator<string> daysOfWeekEnumerator = daysOfWeek.GetEnumerator();

    foreach (var dayOfWeek in daysOfWeekEnumerator)
    {
        Console.WriteLine($"{dayOfWeek} is a beautiful day");
    }

    // You can use discards as parameters to lambda expressions.
    // This convenience enables you to avoid naming the argument, and the compiler may avoid using it. You use the _ for any argument.
    Func<int, int, int> constant = static (_, _) => 42;
    int constantResult = constant(5, 500);

    // you can now apply attributes to local functions. For example, you can apply nullable attribute annotations to local functions.
    string[] lines = { "test_123", "123", null };
    Process(lines, "test");
}

/// <summary>
/// You can now apply attributes to local functions. For example, you can apply nullable attribute annotations to local functions.
/// </summary>
#nullable enable
static void Process(string?[] lines, string mark)
{
    foreach (var line in lines)
    {
        if (IsValid(line))
        {
            // Processing logic...
        }
    }

    bool IsValid([NotNullWhen(true)] string? line)
    {
        return !string.IsNullOrEmpty(line) && line.Length >= mark.Length;
    }
}

#endregion