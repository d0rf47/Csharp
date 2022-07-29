class Program
{
    public static IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        List<string> returnValues = new ();
        foreach(string w in words)
        {
            bool isValid = true;
            for(int i = 1; i < pattern.Length; i++)
            {                
                if(pattern[i] == pattern[i-1] && w[i] != w[i-1])
                    isValid = false;
                if(pattern[i] != pattern[i-1] && w[i] == w[i-1])
                    isValid = false;                                     
                if( pattern.Where((c,index) => index != i).ToList().FindIndex((c) => c == pattern[i]) 
                    != w.Where((c,index) => index != i).ToList().FindIndex((c) => c == w[i]) )
                {
                    isValid = false;   
                }
            }
            if(isValid)
                returnValues.Add(w);
        }
        return returnValues;
    }

    static void Main(string[] args)
    {
        string[] words = {"abc","cba","xyx","yxx","yyx"}; //["abc","deq","mee","aqq","dkd","ccc"]
        string pattern = "abc"; //abb
        List<string> output = FindAndReplacePattern(words, pattern).ToList();        
        foreach(string s in output)
            Console.WriteLine(s);
    }
}