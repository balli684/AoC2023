using System.Globalization;
using System.Text.RegularExpressions;

partial class Program
{
    static void Main()
    {
        string filePath = @"../../../Input.txt";

        Dictionary<string, string> replacements = new()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
        
        try
        {
            using StreamReader sr = new(filePath);
            string line;
            int output = 0;
            List<string> numbers = [];
            while ((line = sr.ReadLine()) != null)
            {
                // Console.WriteLine(line);
                int i = 1;
                do 
                {
                    string part = line[..i];
                    numbers = MyRegex().Matches(part).Cast<Match>().Select(m => m.Value.ToLower()).ToList();
                    i++;
                } while (numbers.Count == 0);
                string firstDigit = numbers.First();
                if (firstDigit.Length > 1)
                {
                    foreach (var replacement in replacements)
                    {
                        firstDigit = firstDigit.Replace(replacement.Key, replacement.Value);
                    }
                }
                // Console.WriteLine(firstDigit);
                i = 1;
                do 
                {
                    string part = line.Substring(line.Length-i,i);
                    numbers = MyRegex().Matches(part).Cast<Match>().Select(m => m.Value.ToLower()).ToList();
                    i++;
                } while (numbers.Count == 0);
                var lastDigit = numbers.First();
                if (lastDigit.Length > 1)
                {
                    foreach (var replacement in replacements)
                    {
                        lastDigit = lastDigit.Replace(replacement.Key, replacement.Value);
                    }
                }
                // Console.WriteLine(lastDigit);
                var number = firstDigit + lastDigit;
                // Console.WriteLine(number);
                output += int.Parse(number);
                // Console.WriteLine(output);
            }
            Console.WriteLine(output);
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        
    }

    [GeneratedRegex(@"(one|two|three|four|five|six|seven|eight|nine|\d)", RegexOptions.IgnoreCase)]
    private static partial Regex MyRegex();

}
