class Program
{
    public static int count(int n, List<int> list)
    {
        var groupedBy = list.GroupBy(item => item);
        int total = 0;
        foreach(var group in groupedBy)
        {
            if (group.Count() > 1 && group.Count() % 2 == 0)
                total += group.Count() / 2;
            else if (group.Count() > 1 && (group.Count() - 1) % 2 == 0)
                total += (group.Count() - 1) / 2;
        }

        return total;
    }
    static void Main(string[] args)
    {
        int n = 9;
        List<int> list = new List<int>{ 10, 20, 20, 10, 10 ,30, 50, 10, 20 };
        Console.WriteLine(count(n, list));

    }
}