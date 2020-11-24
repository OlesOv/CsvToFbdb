using System;
using System.IO;

namespace CsvToFbdb
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles(@"D:\Projects\New folder\");
            foreach(var path in filePaths)
            {
                string text = File.ReadAllText(path);
                text = text.Replace("\"", "''");
                File.WriteAllText(path, text);
                var CsvReader = new CSVReader(path);
                FBDBController fb = new FBDBController("SYSDBA", "Root3571592468", "localhost:recipe_book");
                Console.WriteLine(fb.TransferProducts(CsvReader.ReadProducts()));
            }
        }
    }
}
