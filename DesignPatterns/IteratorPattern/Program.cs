using System.Collections;
using System.Collections.Generic;


namespace Falconi.DesignPatterns.Iterator
{

    class IteratorClass
    {
        static void Main(string[] args)
        {
            var collection = new DaysInMonthCollection();
            foreach (var month in collection)
            {
                Console.WriteLine($"Days In {month.Date} - {month.Days}");
            }
        }
    }
    /// <summary>
    /// Sample Type to iterate through
    /// Represents a month within a given year
    /// And the days in that month
    /// </summary>
    class MonthWithDays
    {
        public string Date { get; set; }
        public int Days { get; set; }
    }

    /// <summary>
    /// Custom Enumerator example
    /// to iterate through a collection of above sample obj
    /// </summary>
    class DaysInMonthEnumerator : IEnumerator<MonthWithDays>
    {

        private int Year = 1;
        /// <summary>
        /// Starts at 0 b/c MoveNext() is called once before returning the first item
        /// to check if collection is empty
        /// </summary>
        private int Month = 0;

        // Typed Version
        public MonthWithDays Current => new MonthWithDays()
        {
            Date = $"{Year.ToString().PadLeft(4, '0')}-{Month}",
            Days = DateTime.DaysInMonth(Year, Month)
        };

        // Generic
        object IEnumerator.Current => Current;

        public void Dispose() { }

        /// <summary>
        /// Increments the month & if month > 12 reset to 1 and
        /// increment the year
        /// </summary>
        /// <returns>Bool for if enumeration is complete</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool MoveNext()
        {
            Month++;

            if (Month > 12)
            {
                Month = 1;
                Year++;
            }

            return Year < 5;
        }
        /// <summary>
        /// Returns collection to beginning
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Reset()
        {
            Month = 0;
            Year = 1;
        }
    }

    /// <summary>
    /// Collection Type representing a collection of
    /// monthwithdays class
    /// </summary>
    class DaysInMonthCollection : IEnumerable<MonthWithDays>
    {
        /// <summary>
        /// Factory method pattern
        /// Typed Version
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MonthWithDays> GetEnumerator()
        {
            return new DaysInMonthEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
