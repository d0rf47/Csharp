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
**Object**: 
