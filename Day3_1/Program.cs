using System.Text.RegularExpressions;

partial class Program
{
    static void Main()
    {
        string filePath = "../../../Input.txt";

        string[] lines = File.ReadAllLines(filePath);
        
        int count = 0;

        int maxLineLength = 0;
        foreach (string line in lines)
        {
            if (line.Length > maxLineLength)
            {
                maxLineLength = line.Length;
            }
        }

        char[,] array = new char[lines.Length + 2, maxLineLength + 2];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i,j] = char.Parse(".");
            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                array[i+1, j+1] = lines[i][j];
            }
        }

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                string character = array[i,j].ToString();
                if(DigitRegex().IsMatch(character))
                {
                    int numberStart = j;
                    string numberString = "";
                    while(DigitRegex().IsMatch(character))
                    {
                        numberString += character;
                        j++;
                        character = array[i,j].ToString();
                    }
                    int numberEnd = j - 1;
                    int number = 0;
                    for (int y = i - 1; y <= i + 1; y++)
                    {
                        for (int x = numberStart - 1; x <= numberEnd + 1; x++)
                        {
                            character = array[y,x].ToString();
                            if(SymbolRegex().IsMatch(character))
                            {
                                number = int.Parse(numberString);
                            }
                        }
                    }
                    count += number;
                }
            }
        }
        Console.WriteLine(count);
        
    }

    [GeneratedRegex(@"\d")]
    private static partial Regex DigitRegex();

    [GeneratedRegex(@"[^0-9\.]")]
    private static partial Regex SymbolRegex();
}
