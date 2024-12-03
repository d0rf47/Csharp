

namespace Falconi.Csharp.NetEssentials
{
    /// <summary>
    /// Write a solution to:
    /// count the files in FileCollection Directory
    /// count how many of each file type there is
    /// Display the total size of each category in bytes
    /// </summary>
    public class Answer
    {
        static List<FileData> FileDatas = new();
        static Dictionary<string, int> FileTypes = new();
        static Dictionary<string, long> FileSizes = new();

        protected struct FileData
        {
            public string FileName { get; set; } = string.Empty;
            public string FileType { get; set; } = string.Empty;
            public long Size { get; set; } = 0;
            public FileData() { }
            public FileData(string fileName)
            {
                FileName = fileName;
            }
            public FileData(FileInfo file)
            {
                FileName = file.Name;
                FileType = file.Extension;
                Size = file.Length;
            }

            public override string ToString()
            {
                return $"FileName: {FileName}, FileType: {FileType}, Size: {Size}";
            }
        }

        public static void GenerateReport()
        {
            const string filename = "Results.txt";
            using (StreamWriter sw = File.CreateText(filename))
            {
                sw.WriteLine("~~~~ Results ~~~~");
                sw.WriteLine($"Total Files: {FileDatas.Count}");
                foreach (var i in FileTypes)
                {
                    sw.WriteLine($"{i.Key} File Count: {i.Value}");
                }
                sw.WriteLine("~~~~ ---- ~~~~");
                sw.WriteLine($"Total Size of Files: {SumFileSizes():N0}");
                foreach (var i in FileSizes)
                {
                    sw.WriteLine($"{i.Key} : {i.Value:N0}");
                }
            }
        }

        public static long SumFileSizes()
        {
            long totalSize = 0;
            foreach (var f in FileSizes)
            {
                totalSize += f.Value;
            }
            return totalSize;
        }

        static void Main(string[] args)
        {

            var files = Directory.EnumerateFiles("~/../FileCollection");

            foreach (var fi in files)
            {
                FileData file = new(new FileInfo(fi));
                FileDatas.Add(file);
                bool added = FileTypes.TryAdd(file.FileType, 1);

                if (!added)
                {
                    FileTypes[file.FileType] = FileTypes[file.FileType] + 1;
                }
                added = FileSizes.TryAdd(file.FileType, file.Size);
                if (!added)
                {
                    FileSizes[file.FileType] = FileSizes[file.FileType] + file.Size;
                }
            }

            foreach (var i in FileTypes)
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
            }
            foreach (var i in FileSizes)
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
            }

            GenerateReport();
        }
    }
}
