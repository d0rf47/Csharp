using System;
namespace mfalconi.Basics.DataTypes
{
    /// <summary>
    /// Basic overview of ValueTypes
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int? nullableNumber = null;
            int nonNullableNumber;            
            nullableNumber = 99;
            nonNullableNumber = nullableNumber ?? 10;
            Console.WriteLine($"The value of the nonNullableNumber is {nonNullableNumber}");
            if(nullableNumber.HasValue)
                Console.WriteLine($"nullableNumber Value is {nullableNumber}");
            else
                Console.WriteLine($"nullableNumber variable has no value");
            
            nullableNumber = null;
            nullableNumber ??=  nonNullableNumber = nullableNumber ?? 10;
            Console.WriteLine($"The value of the nonNullableNumber is {nonNullableNumber}");
            
        }
    }
}