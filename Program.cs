using System;
using System.IO;

public class FileReader
{
    public static string ReadTextFromFile(string filePath)
    {
        try
        {
            // Проверяем существование файла
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не найден: {filePath}");
            }
            
            // Читаем весь текст из файла
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        // Укажите путь к вашему файлу
        string filePath = @"/Users/lamaks/Documents/CodeSpace/C#/TextReader/test_book.txt";
        
        // Вызываем функцию для чтения файла
        string fileContent = FileReader.ReadTextFromFile(filePath);
        
        // Проверяем, что файл был успешно прочитан
        if (fileContent != null)
        {
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine("=================");
            Console.WriteLine(fileContent);
            Console.WriteLine("=================");
            Console.WriteLine($"Файл успешно прочитан. Количество символов: {fileContent.Length}");
        }
        else
        {
            Console.WriteLine("Не удалось прочитать файл.");
        }
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}