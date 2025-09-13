using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        ["син"] = "Blue",
        ["крас"] = "Red",
        ["зел"] = "Green",
        ["желт"] = "Yellow",
        ["бел"] = "White",
        ["черн"] = "Black",
        ["оранж"] = "Orange",
        ["фиолет"] = "Purple",
        ["бирюз"] = "Turquoise",
        ["ультрамарин"] = "Ultramarine",
        ["небесн"] = "SkyBlue",
        ["ал"] = "Crimson",
        ["борд"] = "Bordeaux",
        ["изумруд"] = "Emerald",
        ["лайм"] = "Lime",
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
        string filePath = @"/Users/lamaks/Documents/CodeSpace/C#/TextReader/test_book.txt";
        string fileContent = FileReader.ReadTextFromFile(filePath);

        if (fileContent != null)
        {
            Console.WriteLine("Info from file:");
            Console.WriteLine("=================");
            Console.WriteLine(fileContent);
            Console.WriteLine("=================");
            Console.WriteLine($"File opened successfully. Quantity of symbols: {fileContent.Length}");

            FindAndCountColors(fileContent);
        }
    }

    static void FindAndCountColors(string text)
    {
        Console.WriteLine("\n=== COLOR ANALYSIS ===");
        
        Dictionary<string, int> colorCounts = new Dictionary<string, int>();
        Dictionary<string, List<string>> colorExamples = new Dictionary<string, List<string>>();

        var words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t' }, 
                             StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var word in words)
        {
            string lowerWord = word.ToLower();
            
            foreach (var colorPair in ColorDictionary.Colors)
            {
                if (lowerWord.Contains(colorPair.Key))
                {
                    string colorName = colorPair.Value;

                    if (colorCounts.ContainsKey(colorName))
                    {
                        colorCounts[colorName]++;
                    }
                    else
                    {
                        colorCounts[colorName] = 1;
                    }
                    
                    if (!colorExamples.ContainsKey(colorName))
                    {
                        colorExamples[colorName] = new List<string>();
                    }
                    if (!colorExamples[colorName].Contains(word))
                    {
                        colorExamples[colorName].Add(word);
                    }
                    break;
                }
            }
        }
        if (colorCounts.Count > 0)
        {
            Console.WriteLine("\nFound colors:");
            Console.WriteLine("==============");
            
            foreach (var color in colorCounts.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{color.Key}: {color.Value} times");
                Console.WriteLine($"  Examples: {string.Join(", ", colorExamples[color.Key].Take(3))}");
                if (colorExamples[color.Key].Count > 3)
                {
                    Console.WriteLine($"  ... and {colorExamples[color.Key].Count - 3} more");
                }
            }
            
            Console.WriteLine($"\nTotal unique colors found: {colorCounts.Count}");
            Console.WriteLine($"Total color occurrences: {colorCounts.Values.Sum()}");
        }
        else
        {
            Console.WriteLine("No colors found in the text.");
        }
    }
}