
public class Solution
{
    public static bool IsAnagram(string s, string t) 
    {
        if(s.Length != t.Length)
            return false;

        int sCount = 0;
        int tCount = 0;
        HashSet<char> hashStrings = new HashSet<char>();
        hashStrings = s.ToHashSet();
        foreach(var c in hashStrings)
        {
            char x = c;
            sCount = s.Count((l) => l == x);
            tCount = t.Count((l) => l == x);
            if(sCount != tCount)
                return false;
        }

        return true;
    }

    static void Main(String[] args)
    {
        string s = "rat";
        string t = "car";
        Console.WriteLine(IsAnagram(s,t));
    }
}