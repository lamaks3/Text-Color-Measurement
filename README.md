Written in C#, cross-platform support
The program allows you to create a PNG image based on the colors found in the text from a .txt file.

How the program works:
1)extracting words from text
2)search for words by roots from a dictionary
3)creating an image where each pixel is a color that appears in the text (in order)

How to use:
1)download SkiaSharp library(write to terminal(for VS code): dotnet add package SkiaSharp)
2)specify the location of yours .txt file in line 37 (ex: string filePath = @"/Users/lamaks/Documents/CodeSpace/C#/TextReader/test_book.txt";)
3)change dictionary called "Colors" in line 12 , where ["root of color(in the language of the book)"]=SKColors.xColor 
(xColor - pixel color, you can find color names for SkiaSharp in the web
4)the final image will be in the root folder of the project

The program was tested on MacOS in Visual Studio Code.
Made by @lamaks3. Free to use)
