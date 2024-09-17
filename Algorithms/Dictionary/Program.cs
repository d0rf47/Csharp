using System;

class Program {
    
    public static void checkMagazine2(List<string> magazine, List<string> note)
    {
         // Step 1: Create a dictionary to store word counts from the magazine
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        
        foreach (string word in magazine)
        {
            if (wordCounts.ContainsKey(word))
                wordCounts[word]++;
            else
                wordCounts[word] = 1;
        }

        // Step 2: Check if all words in the note can be found in the magazine
        foreach (string word in note)
        {
            if (wordCounts.ContainsKey(word) && wordCounts[word] > 0)
            {
                wordCounts[word]--; // Use the word from the magazine
            }
            else
            {
                Console.WriteLine("No");
                return;
            }
        }

        Console.WriteLine("Yes");
    }

    public static void checkMagazine(List<string> magazine, List<string> note)
    {        
        Dictionary<int, string> dic = new();
        for(int i = 0; i < note.Count; i++)
        {
            if (magazine.Contains(note[i]))
            {
                dic.Add(i, note[i]);
                magazine.RemoveAt(magazine.IndexOf(note[i]));
            }
        }

        if(note.Count > dic.Count) {
            Console.WriteLine("No");
            return;
        }
        for(int i = 0; i < dic.Count; i++)
        {
            if (dic[i] != note[i])
            {
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
    }

    public static void Main(string[] args)
    {
        List<string> s1 = new() { "two", "times", "three", "is", "not", "four" };
        List<string> s2 = new() { "two", "times", "two", "is", "four" };
        Program.checkMagazine(s1, s2);
    }

}