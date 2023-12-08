
class Program
{
    static void Main()
    {

        string filePath = "../../../Input.txt";
        List<string> input = [.. (File.ReadAllLines(filePath))];

        List<string[]> hands = input.Select(x => x.Split(' ')).ToList();

        int output = 0;

        int i = 0;
        while (i < hands.Count)
        {
            var charCount = hands[i][0].GroupBy(c => c).Select(g => g.Count()).ToList();
            charCount.Sort();

            switch (string.Join("",charCount))
            {
                case "11111":
                    hands[i][0] = "1" + hands[i][0];
                    break;
                case "1112":
                    hands[i][0] = "2" + hands[i][0];
                    break;
                case "122":
                    hands[i][0] = "3" + hands[i][0];
                    break;
                case "113":
                    hands[i][0] = "4" + hands[i][0];
                    break;
                case "23":
                    hands[i][0] = "5" + hands[i][0];
                    break;
                case "14":
                    hands[i][0] = "6" + hands[i][0];
                    break;
                case "5":
                    hands[i][0] = "7" + hands[i][0];
                    break;
            }

            hands[i][0] = hands[i][0]
                            .Replace('A','F')
                            .Replace('K','E')
                            .Replace('Q','D')
                            .Replace('J','C')
                            .Replace('T','B');
            i++;
        }

        hands = [.. hands.OrderBy(arr => arr[0])];

        i = 0;
        while (i < hands.Count)
        {
            output += (i+1) * int.Parse(hands[i][1]);
            i++;
        }
        Console.WriteLine(output);

    }
}
