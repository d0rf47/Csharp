# Features of .NET Core 

## Memory Management
- .NET uses a _Managed Memory Model_
    - the CLR (Common Language Runtime) manages memory allocation & deallocation
    - this is known as **_Garbage Collection_** (GC)
    - The GC is part of `System` and found in `System.GC`
    - when new objects are created the CLR allocates the memory for said object on the heap.
    - Heap: Is an area of system memory reserved for the application and kept separate from other programs to keep each programs memory safe from each other. 
    - As long as memory is available the GC will allocate memory as needed, but as free space runs out it will determine what can be safely de-allocated and remove said objects from memory to free up space.
    - memory is considered in use as long as objects/variables remain in scope.
    - the GC Can be explicitly called to perform clean up, but is rarely every required to be done this way since the process is mostly automatic and highly optimized
- Exceptions
    - 
### Memory States
1. Free: block of memory is free with no references and available for allocation
1. Reserved: The block is available for use by the application but protected from other applications to use. However it cannot be used for storage until the block is committed 
1. Committed: The block has been assigned to physical storage

# Data Types
## Reference Vs. Value

### Value Types  
- contains a direct instance of the variable. (it holds its own copy of the data being stored). This means that operations on Value Types affect only that specific instance of the variable.
- Passed by copy, meaning a copy is made when passing a value to a method and then operated on meaning changes to the copy **do not** affect the original
- Value Types are stored on the _stack_ (LIFO) (with some exceptions explained below) which means memory allocation and de-allocation is more efficient than for references reference types. 
- Example
```
int x = 0;
function void ChangeInt(int y)
{ 
    y++;
    Console.WriteLine(y);
}
Console.WriteLine(x); // output = 0
ChangeInt(x); // output = 1
Console.WriteLine(x); //output = 0
```
- Value types include all built-in types
    - Integers (int), Floating point (float, double, decimal), Boolean (bool), Characters (char)
    - Enum, Struct & Tuples are also Value Types

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

**Tuple:** Allows the grouping of different data types into a simple, lightweight data structure. Does not support added methods, but can be used with .NET provided methods.
- Most common use case is for return types, allows you to return different types & value without specifying `out` parameters. They can be defined with or without field names. If field names are not specified, the default (ItemX) is used.
```
(double, int) t1 = (4.5, 3); //declaration
Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}."); // access

var t = (Sum: 4.5, Count: 3); //field name declaration example
Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");
```
- Value Tuples rely on `System.ValueTuple` which is a value type and mutable. All data members are fields
- `System.Tuple` are reference types and immutable and all data members are properties

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
    
### Reference types 
- are objects which store a reference to data
- Contains a reference to an instance of the variable
- This is an important distinction for performance reasons
    - Value types are allocated on the _stack_ whereas reference types are allocated on the _heap_
    - Value types can be used as reference types by using keywords `ref` `out` `in`
    - The allocation type impacts access and assignment
        - passing value types without a reference keyword will result in a copy being created and passed to the method.
- are complex data types that are passed by reference
- This means when a reference type is passed to a method any changes to the variable will persist after the function call has been completed
- Example:
```
using System;
					
class Child
{
    private int age;
    private string name;
    public bool isOld;
    // Default constructor:
    public Child()
    {
        name = "N/A";
    }

    // Constructor:
    public Child(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Printing method:
    public void PrintChild()
    {
        Console.WriteLine($"{name}, {age} years old.");
        Console.WriteLine($"Child is old {isOld}");
    }
	public int GetAge()
	{
		return age;
	}
}

class StringTest
{
	static void ChangeOld(Child c)
	{
		if(c.GetAge() >= 50)
		{
			c.isOld = true;
		}
	}
    static void Main()
    {
        // Create objects by using the new operator:
        Child child1 = new ("Craig", 11);
        Child child2 = new ("Sally", 50);

        // Create an object using the default constructor:
        Child child3 = new ();

        // Display results:
        Console.Write("Child #1: ");
        child1.PrintChild();
        Console.Write("Child #2: ");
        child2.PrintChild();
        Console.Write("Child #3: ");
        child3.PrintChild();
		ChangeOld(child2);
		Console.Write("Child #2: ");
		child2.PrintChild();
    }
}
/* Output:
//Child #1: Craig, 11 years old.
//Child is old False
//Child #2: Sally, 50 years old.
//Child is old False
//Child #3: N/A, 0 years old.
//Child is old False
//Child #2: Sally, 50 years old.
//Child is old True
*/
```
- Any class, interface, delegate or record are reference types and most often are user defined. 
- a few built-in reference types exist in C# and include
    - Object, String, Delegate, Dynamic

#### Built-in Reference Types
##### Object
- Is a built-in alias for `System.Object`
- All types in the .net ecosystem (including value types) inherit directly or indirectly from `System.Object`
- `Object` can be assigned values of any type since technically all types in .net are objects
- **Boxing**: Is the term used when a value type variable is converted to an object 
    - Boxing is performed by casting _implicitly_
    - eg.  
```
        int i = 123;
        object o = i; // boxing occurs here
```
- **Unboxing**: Is the term used to convert a value type variable stored as an object back into a value type.
    - is performed by casting _explicitly_
    - requires checking the object instance matches the requested unboxed type
    - eg.
```
    o = 123;
    i = (int)o;  // unboxing 
```
- when the CLR boxes a value type it is wrapping the value inside an `Object` instance and thus stores the variable on the managed heap.
- Boxing is computationally expensive since new objects must be created in memory to be used
- unboxing can result in 2 common exceptions
    1. `NullReferenceException` - when a null value is attempted to be unboxed
    1. `InvalidCastException` - when an incompatible reference type is used



##### String
- Is an alias for `System.String`
- Is a sequence of zero or more unicode Characters
- despite being a reference type, equality operators `==` & `!=` perform a value based check to allow for a more intuitive use
- String objects are _immutable_ meaning when changing the content of a String object, a new object is actually created in memory and the previously held memory is made available
- `[ ]` operator can be used for readonly access to individual characters in a string
- Include some built-in properties and methods
    - Length - property that tracks the number of characters in the string
    - Join() - used to join strings with a specified delimiter
        - arg1 is the delimiter 
        - arg2 is a collection type (array, list etc.)
    - Concat() - used to combine strings together without any delimiter
    - Compare(s1,s2);
        - performs an ordinal comparison and returns and int
        - used to facilitate sorting on strings
        - < 0 means s1 comes before s2
        - == 0 means they are the same position
        - \> 0 means s1 comes after s2
    - Replace("wordtofind", "replacement") - replaces s1 with s2 if found and returns a new string object

- **String Literals**
    - are a type of String and can be written in 3 formats
    - are enclosed in a minimum of 3 double quotes 
    - eg.
```
    """
    This is a multi-line
    string literal with the second line indented.
    """
```
```
    var message = """
    "This is a very important message."
    """;
    Console.WriteLine(message);
    // output: "This is a very important message."
```
- **Interpolation**
    - There are 2 methods of inserting data into strings
        1. Placeholder method: `Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);`
        1. Interpolation method: `Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");`
    - Formatting: `{<interpolationExpression>[,<alignment>][:<formatString>]}`
- **Concatenation**
    - is the process of combining 2 or more strings 
    - `String.Concat(args)`
    -  `String.Join('char', strings);
    - eg.    
```
        string [] strings = {"one", "two", "three"};
		string outString = String.Concat(strings);
		Console.WriteLine(outString);   // output: onetwothree
		outString = String.Join('.', strings);
		Console.WriteLine(outString);   // output: one.two.three
		outString = String.Join("---", strings);
		Console.WriteLine(outString);   // output: one---two---three
```
- **Searching**
    - `Contains("string")` - used to determine if a string contains specified content
        - By default it is _case sensitive_ but this can be overridden using additional parameters
    - eg.
```
    string testString = "The quick brown Fox jumps over the lazy Dog";
    Console.WriteLine($"{testString.Contains("fox")}")   // output: False
    Console.WriteLine($"{testString.Contains("fox"), StringComparison.CurrentCultureIgnoreCase}")   // output: True
```
- `StartsWith(s1)` - used to check if a string begins with the specified argument
- `EndsWith(s1)` - used to check if a string ends with the specified argument
- `IndexOf(s1)` - returns an int showing the starting position of the specified string
- `LastIndexOf(s1)` - returns an int showing the starting position of the specified string, but finds the last instance of the string to search for and searches from the end of the string
    - both indexOf methods return -1 if no match is found

- **Determining Whitespace** 
- `String.IsNullOrEmpty()`;
- `String.IsNullOrWhiteSpace()`;

**Parsing Numbers**
- involves converting numeric strings into their appropriate numeric value type
- `Parse()` methods are available on all numeric types
- `Parse()` methods will throw an exception `FormatException` if an incompatible numeric string is provided as the argument
- `TryParse()` returns a bool and prevents format exception errors. It performs the parse on the `out` parameter and handles the exception internally
    - `public static bool TryParse (string? s, IFormatProvider? provider, out int result);`

**Formatting Numerical Data**
- `$"{var, [alignment]:[format][precision]}"`
list of types
B,b - binary String
C,c - Currency
