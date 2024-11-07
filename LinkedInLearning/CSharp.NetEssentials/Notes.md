# Data Types
## Reference Vs. Value

### Value Types  
- contains a direct instance of the variable
- allocated on the stack (with a few exceptions explained below)
- Passed by copy, meaning a copy is made when passing a value to a method and then operated on meaning changes to the copy **do not** affect the original
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


    
### Reference types 
- are objects which store a reference to data
- Contains a reference to an instance of the variable
- This is an important distinction for performance reasons
    - Value types are allocated on the _stack_ (LIFO) whereas reference types are allocated on the _heap_
    - Value types can be used as reference types by using keywords `ref` `out` `in`
    - The allocate type impacts access and assignment
        - passing value types without a reference keyword will result in a copy being created and passed to the method.

- are complex data types that are passed by reference
- This means when a reference type is passed to a method any changes to the type will persist after the function called has been completed
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
- 