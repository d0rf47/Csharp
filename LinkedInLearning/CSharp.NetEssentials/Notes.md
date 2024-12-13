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



##### Strings
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
<html xmlns:v="urn:schemas-microsoft-com:vml"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns="http://www.w3.org/TR/REC-html40">

<head>

<meta name=ProgId content=Excel.Sheet>
<meta name=Generator content="Microsoft Excel 15">
<link id=Main-File rel=Main-File
href="file:///C:/Users/falcomic/AppData/Local/Temp/msohtmlclip1/01/clip.htm">
<link rel=File-List
href="file:///C:/Users/falcomic/AppData/Local/Temp/msohtmlclip1/01/clip_filelist.xml">
<style>
	{mso-displayed-decimal-separator:"\.";
	mso-displayed-thousand-separator:"\,";}
@page
	{margin:.75in .7in .75in .7in;
	mso-header-margin:.3in;
	mso-footer-margin:.3in;}
tr
	{mso-height-source:auto;}
col
	{mso-width-source:auto;}
br
	{mso-data-placement:same-cell;}
td
	{padding-top:1px;
	padding-right:1px;
	padding-left:1px;
	mso-ignore:padding;
	color:black;
	font-size:11.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:"Aptos Narrow", sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border:none;
	mso-background-source:auto;
	mso-pattern:auto;
	mso-protection:locked visible;
	white-space:nowrap;
	mso-rotate:0;}
.xl63
	{mso-number-format:"\0022$\0022\#\,\#\#0\.00_\)\;\[Red\]\\\(\0022$\0022\#\,\#\#0\.00\\\)";}
.xl64
	{mso-number-format:Scientific;}
.xl65
	{mso-number-format:Standard;}
</style>
</head>

<body link="#467886" vlink="#96607D">

Format Specifier | Name | Example | Precision Example | Supports
-- | -- | -- | -- | --
B, b | Binary | 42("B") = 101010 | 255("b16") = 0000000011111111 | Int
C, c | Currency | 123.456 ("C", en-US) = $123.46 | -123.456 ("C3", fr-FR) = -123,456   € | All numerics
D, d | Decimal | 1234   ("D") | -1234   ("D6") = -001234 | Int
E, e | Exponential | 1052.0329112756 ("E", en-US) = 1.052033E+003 | -1052.0329112756 ("e2", en-US) =   -1.05e+003 | All numerics
F, f | Fixed-point | 1234.567 ("F", en-US) = 1234.57 | 1234 ("F1", en-US) = 1234.0 | All numerics
G, g | General | -123.456 ("G", en-US) = -123.456 | 123.4546 ("G4", en-US) = 123.5 | All numerics
N, n | Number | 1234.567 ("N", en-US) = 1,234.57 | 1234   ("N1", en-US) = 1,234.0 | All numerics
P, p | Percent | 1 ("P", en-US) = 100.00% | -0.39678   ("P1", en-US) = -39.7% | All numerics
R, r | Round-trip | 123456789.12345678 ("R") = 123456789.12345678 | `-1234567890.12345678 ("R") = -1234567890.1234567 | Singe, Double, Big Int
X,   x | Hexadecimal | 255   ("X") = 55 | 255   ("x4") = 00ff | Int
</body>
</html>

- Examples
```
    int dec = 1234;
    int[] quarters = {1,2,3,4};
    double[] decimals = {.123, .456, .789};
    int[] sales = {10000, 15000, 20000,25000};
    Console.WriteLine($"{dec.ToString("D12")} {dec.ToString("d")}");    // output: 000000001234 1234
    Console.WriteLine($"{quarters[0], 12}");                            // output:            1
    Console.WriteLine($"{sales[0], 12:C0}");                            // output:      $10,000
    Console.WriteLine($"{decimals[0], 12:P0} {decimals[1], 12:P2}");    // output:         12 %      45.60 %
```

- **Date-Time Conversion**
    - `DateTime` Struct is the basic Type used for dealing with Date or Times in C#
    - It includes a series of built-in functions used for parsing, processing and comparing dates/times
    - `DateOnly` is used when only the Date is required
    - `TimeOnly` is used when only the time is required
    - `TimeSpan` is used to represent a duration of time and is returned when operations are performed on `DateTime` variables
examples:
```
var today = DateTime.Now;
DateOnly todayDate = DateOnly.FromDateTime(today);
TimeOnly todayTime = TimeOnly.FromDateTime(today);
DateTime AprilFools = new(today.Year, 4, 1);    // Format is yyyy, mm, dd
DateTime NewYearsDay = new(today.Year, 1, 1);
Console.WriteLine($"It currently is {today.ToString()}");
Console.WriteLine($"It currently is {today:F}");
Console.WriteLine($"It currently is {today:d}");
Console.WriteLine($"It currently is {today:D}");
Console.WriteLine($"It currently is {todayDate.ToString()}");
Console.WriteLine($"It currently is {todayTime.ToString()}");

today = today.AddDays(9);
Console.WriteLine($"It will be {today.ToString()}");

today = today.AddMonths(9);
Console.WriteLine($"It will be {today.ToString()}");

TimeSpan interval = AprilFools - NewYearsDay;
Console.WriteLine($"Difference btwn April Fools & New Years Day: {interval}");

output:
It currently is 11/19/2024 3:38:27 PM
It currently is Tuesday, November 19, 2024 3:38:27 PM
It currently is 11/19/2024
It currently is Tuesday, November 19, 2024
It currently is 11/19/2024
It currently is 3:38 PM
It will be 11/28/2024 3:38:27 PM
It will be 8/28/2025 3:38:27 PM
Difference btwn April Fools & New Years Day: 91.00:00:00
```

# Working with Files
- The primary class used for accessing File methods is defined in `System.IO.File` in the `File Class`
- This class provides a series of static methods we can use to work with various file types in C#
- typical operations include: Copying, moving, renaming, creating, opening, deleting, and appending to a single file.
- Files also contain meta-data which can be used. They can be accessed, read and written to and include data such as author, last edit, creation timestamp, hidden or not etc. 

## CreateText
- Is used to create basic Text files.
- this method will always overwrite data that exists in the file if it already exists. 
    - It can be useful to check if a file exists first before using the Create methods to ensure data integrity.
Example
```
const string fileName = "TestFile.txt";

using(StreamWriter sw = File.CreateText(fileName))
{
    sw.WriteLine("This is a text file");
}
```
## WriteAllText
- Is used to write to a File and will overwrite the contents of the file
- Creates the File if doesn't exist
example
`File.WriteAllText(fileName, "The file has been overwritten");`

## Delete
- Used to remove a file
- Can throw and exception if file is not accessible for use or does not exist

Example combining the various methods usable on Files via the File Class
```
const string fileName = "TestFile.txt";
string readFileData = string.Empty;
string userInput = string.Empty;

if(File.Exists(fileName))
{    
    File.WriteAllText(fileName, "The file has been overwritten");
    File.AppendAllText(fileName, Environment.NewLine + "This has been appended");
}
else
{
    using(StreamWriter sw = File.CreateText(fileName))
    {
        sw.WriteLine("This is a text file!");        
    }
     
}

readFileData = File.ReadAllText(fileName);
Console.WriteLine(readFileData);
Console.WriteLine("Do you want to remove the file? Yes/No");

userInput = Console.ReadLine();
if(userInput.ToLower() == "yes" || userInput.ToLower() == "y")
{
    File.Delete(fileName);
    Console.Clear();
    Console.WriteLine("File Deleted!");
}
else
{
    Console.Clear();
    Console.WriteLine("Goodbye World");
}

```
## SetAttributes / GetAttributes
- Provides access to set/get File meta data

## FileInfo Objects
- Provides access to all of a File's properties in a single object

## Directories
- Are a structuring mechanism used to organize files 
- Many of the methods used to interact with directories are shared with Files with the exception being the methods are found in the `Directory` Class instead of File
Examples
```
string currentPath = Directory.GetCurrentDirectory();
List<string> directories = new(Directory.EnumerateDirectories(currentPath));

directories.ForEach(d => Console.WriteLine(d));

Console.WriteLine($"PWD = {currentPath}");
```

#### Regular Expressions (RegEx)
- Defined in `System.Text.RegularExpressions` - This is not a in the default namespaces and must be explicitly imported
- Used for pattern Matching in text.
- It can also be used for text replacements 
- .Net provides a standard library API that provides useful methods for utilizing Regular expressions.
##### Drawbacks
- Possible Performance Issues 
    - Backtracking is an issue caused by poorly constructed RegEx's 
    - it causes the RegEx processor to execute slowly
    - Timeout values can be used to prevent this issue from becoming a performance bottleneck and affecting the application
    
- Security issues

**Using Statement**:
- Is a keyword used to define a scope of use for a resource which will get disposed of once the program has excited with `Using` scope. 
- It is used to ensure proper disposal of object instances that are not automatically handled by the .net Garbage Collector.
- `using` syntax ensure we do not leave object references open which are not longer needed.
