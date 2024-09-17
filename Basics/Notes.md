# Udemy C# Master Class Notes

## Chapter 1: DataTypes & Variables
Reference: [Value types - C# reference | Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)  
[Textbook](https://algs4.cs.princeton.edu/home/)
### Value Types:
A variable of Value Type contains an instance of said type (it holds its own copy of the data being stored). This means that operations on Value Types affect only that specific instance of the variable. Value Types are stored on the _stack_ which means memory allocation and deallocation is more efficient than reference types. 
 Non Built-in Value Types include: Struct, Enum the rest are known as simple types

#### Simple Types
**Int:** A standard mathematical integer number. Ex. 1  or 32
Char: represents a single character and is enclosed in single quotes. Ex. ‘!’
**Double:** is used to store floating point numbers (smaller decimals). Ex. 3.14. It is used primarily for decimal numbers where there is not a large amount of numbers following the decimal place since the more numbers following the decimal point, the less accurate the value held truly is.
**Decimal:** was created to solve the issue of double floating point inaccuracy. It retains more accuracy with more numbers following the decimal. It also includes a terminating value (suffix) which indicates the type (m) This type should always be used when values and/or calculations require as much accuracy as possible. Examples include monetary value calculations or mathematics. Doubles can be used to increase performance where accuracy is less important such as for game physics.
**Bool:** true or false
#### Value Types
**Enum:** is a value-type. An enumeration of a set of named constants which map to an underlying integral numeric type. By default, enums are mapped from 0 base for each member, however explicit setting of the underlying int is possible. A good example of this would be HTTP error codes.
```
	enum ErrorCode : ushort
    {
	    None = 0,
      	Unknown = 1,
      	ConnectionLost = 100,
      	OutlierReading = 200
   	}
```
Enums cannot contain any logic. To add methods/functionality extensions methods are used in C#.

**Struct:**  Is a value type. It can be used to encapsulate data and related functionality (methods). They also contain Value Semantics. The common usage for structs is when implementing a data container where its overall behaviour is less important. .Net Uses structs for concepts such as DateTime. It includes some related functionality like toString() etc. 
```
    public struct TaggedInteger
        {
        public int Number;
        private List<string> tags;


        public TaggedInteger(int n)
        {
            Number = n;
            tags = new List<string>();
        }


        public void AddTag(string tag) => tags.Add(tag);


        public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
    }
```

**Nullable**: Is an instance of `System.Nullable<T>` It allows for assigning a value of `NULL` to a variable and provides some extra features we can access such as:

```
int? nullableNumber = null;
if(nullableNumber.HasValue)
    Console.WriteLine($"Value of number is {nullableNumber}");
else
    Console.WriteLine($"Variable has no number");
```
Nullable types are used in situations where we may need to represent the nothingness of a variable such as when loading data from a database, not all columns may have some data value and therefore equal nothing. This is represented in a program as `NULL` and thus we can make use of the nullable type to represent such data. 

When assigning a nullable variable to a non-nullable underlying variable we commonly must specify what should replace the `NULL` value on assignment. This is done using the **_null-coalescing operator_**: `??` This returns the valye of the left side operand **if it is not null** else it evalutes and returns the right side value.

```
int? nullableNumber = null;
int nonNullableNumber = 0;            
nonNullableNumber = nullableNumber ?? 10; // nonNullableNumber == 10
```

```
int? nullableNumber = null;
int nonNullableNumber;            
nullableNumber = 99;
nonNullableNumber = nullableNumber ?? 10;
Console.WriteLine($"The value of the nonNullableNumber is {nonNullableNumber}"); // output = 99
if(nullableNumber.HasValue)
    Console.WriteLine($"nullableNumber Value is {nullableNumber}"); // output = 99
else
    Console.WriteLine($"nullableNumber variable has no value");

nullableNumber = null;
nullableNumber ??=  nonNullableNumber = nullableNumber ?? 10; //replaces if x is null variable = expression syntax
Console.WriteLine($"The value of the nonNullableNumber is {nonNullableNumber}"); //output = 10
```

### Reference Types

String: an array of characters stored in double quotes.  Ex. “Mike is super kewl.” String types also include a predefined set of operations such as concatination, manipulation and interpolation. 

