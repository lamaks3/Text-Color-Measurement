using SkiaSharp;
public class FileReader
{
    public static string ReadTextFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}

class Program
{
    public static Dictionary<string, SKColor> Colors { get; } = new Dictionary<string, SKColor>
{
    ["син"] = SKColors.Blue,
    ["крас"] = SKColors.Red,
    ["зел"] = SKColors.Green,
    ["желт"] = SKColors.Yellow,
    ["бел"] = SKColors.White,
    ["черн"] = SKColors.Black,
    ["оранж"] = SKColors.Orange,
    ["фиолет"] = SKColors.Purple,
    ["бирюз"] = SKColors.Turquoise,
    ["ультрамарин"] = SKColors.Indigo,
    ["небесн"] = SKColors.SkyBlue,
    ["борд"] = SKColors.Maroon, 
    ["изумруд"] = SKColors.Green, 
    ["лайм"] = SKColors.Lime,
    ["золот"] = SKColors.Gold,
    ["серебр"] = SKColors.Silver,
    ["роз"] = SKColors.Pink,
    ["сер"] = SKColors.Gray,
    ["коричн"] = SKColors.Brown,
    ["голуб"] = SKColors.LightBlue
};
    static void Main()
    {
        string filePath = @"/Users/lamaks/Documents/CodeSpace/C#/TextReader/test_book.txt";
        string fileContent = FileReader.ReadTextFromFile(filePath);

        if (fileContent != null)
        {
            Console.WriteLine($"File opened. Length: {fileContent.Length}");
            FindAndCountColors(fileContent);
        }
    }

    static void FindAndCountColors(string text)
    {
        List<SKColor> ColorsList = new List<SKColor>();
        var words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            string lowerWord = word.ToLower();
            
            foreach (var colorPair in Colors)
            {
                if (lowerWord.Contains(colorPair.Key))
                {
                    ColorsList.Add(colorPair.Value);
                    break;
                }
            }
        }
        Console.WriteLine($"Number of colors found: {ColorsList.Count}");
        Draw(ColorsList.Count, ColorsList);

    }

    static void Draw(int ColorsNumber,List<SKColor> ColorList)
    {
        int size = (int)Math.Ceiling(Math.Sqrt(ColorsNumber));
        using (var bitmap = new SKBitmap(size, size))
        {
        int color_index = 0;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (color_index < ColorList.Count)
                {
                    bitmap.SetPixel(x, y, ColorList[color_index]);
                    color_index++;
                }
                else
                {
                    break;
                }
            }
            if (color_index >= ColorList.Count) break;
        }
            using (var image = SKImage.FromBitmap(bitmap))
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = File.OpenWrite("photo_res.png"))
            {
                data.SaveTo(stream);
            }
        }
        Console.WriteLine("Image saved as photo_res.png");
    }
}