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

public static class ColorDictionary
{
    public static Dictionary<string, string> Colors { get; } = new Dictionary<string, string>
    {
        // Основные цвета
        ["син"] = "Blue",
        ["крас"] = "Red",
        ["зел"] = "Green",
        ["желт"] = "Yellow",
        ["бел"] = "White",
        ["черн"] = "Black",
        ["оранж"] = "Orange",
        ["фиолет"] = "Purple",

        // Синие оттенки
        ["лазур"] = "Azure",
        ["бирюз"] = "Turquoise",
        ["ультрамарин"] = "Ultramarine",
        ["небесн"] = "SkyBlue",

        // Красные оттенки
        ["ал"] = "Crimson",
        ["малинов"] = "Raspberry",
        ["борд"] = "Bordeaux",
        ["вишн"] = "Cherry",

        // Зеленые оттенки
        ["изумруд"] = "Emerald",
        ["оливк"] = "Olive",
        ["лайм"] = "Lime",
        ["мят"] = "Mint",

        // И еще много других цветов...
        ["золот"] = "Gold",
        ["серебр"] = "Silver",
        ["роз"] = "Pink",
        ["сер"] = "Gray",
        ["коричн"] = "Brown",
        ["голуб"] = "LightBlue"
    };

    public static bool TryGetColor(string root, out string colorName)
    {
        return Colors.TryGetValue(root, out colorName);
    }
}

class Program
{
    static void Main()
    {
        //direct path to file
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