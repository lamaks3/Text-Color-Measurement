using System;
using System.IO;

public class FileReader
{
    public static string ReadTextFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"There is no file: {filePath}");
            }
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"File reading error: {ex.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        string filePath = @"/Users/lamaks/Documents/CodeSpace/C#/TextReader/test_book.txt";
        string fileContent = FileReader.ReadTextFromFile(filePath);
        
        if (fileContent != null)
        {
            Console.WriteLine("Info from file:");
            Console.WriteLine("=================");
            Console.WriteLine(fileContent);
            Console.WriteLine("=================");
            Console.WriteLine($"File opened succesfully. Quantity of symbols: {fileContent.Length}");
        }    
    }
}