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
