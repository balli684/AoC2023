using System.Text.RegularExpressions;

partial class Program
{
    static void Main()
    {
        string filePath = @"../../../Input.txt";

        try
        {
            using StreamReader sr = new(filePath);
            string line;
            int output = 0;
            while ((line = sr.ReadLine()) != null)
            {
                var numbers = MyRegex().Matches(line).Cast<Match>().Select(m => m.Value).ToList();
                if (numbers.Count > 0)
                {
                    string number = numbers.First() + numbers.Last();
                    output += int.Parse(number);
                    // Console.WriteLine(number);
                }
                // Console.WriteLine(line);  
            }
            Console.WriteLine(output);
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        
    }

    [GeneratedRegex(@"\d")]
    private static partial Regex MyRegex();
}
