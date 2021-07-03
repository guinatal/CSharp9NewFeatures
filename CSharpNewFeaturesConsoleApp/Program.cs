using CSharpNewFeaturesConsoleApp.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Top-level statements
/// Top-level statements remove unnecessary ceremony from many applications.
/// Only one file in your application may use top-level statements. If the compiler finds top-level statements in multiple source files, it's an error.
/// It's also an error if you combine top-level statements with a declared program entry point method, typically a Main method.
/// In a sense, you can think that one file contains the statements that would normally be in the Main method of a Program class.
/// Azure Functions is an ideal use case for top-level statements.
/// </summary>
/// 

Console.WriteLine("Hello World!");

_ = args.Length;

RecordTypes();

InitOnlySetters();

/// <summary>
/// Record Types
/// C# 9.0 introduces record types.
/// You use the record keyword to define a reference type that provides built-in functionality for encapsulating data.
/// While records can be mutable, they are primarily intended for supporting immutable data models.
/// </summary>
static void RecordTypes()
{
    // example 1 => immutable properties
    Person person1 = new("Guilherme", "Mello");
    // person.FirstName = "Lucas"; // => compilation error
    Console.WriteLine(person1);

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
    Person person2 = person1 with { FirstName = "Lucas" };
    Console.WriteLine(person2);

    // example 5 => inheritance
    // A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.
    Desk desk1 = new("desk", "blue");
    Console.WriteLine(desk1);
}

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