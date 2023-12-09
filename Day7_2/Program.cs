
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
            var jokerCount = hands[i][0].Count(t => t == 'J');

            switch (string.Join("",charCount), jokerCount)
            {
                case ("5", 0):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("5", 5):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("14", 1):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("23", 2):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("23", 3):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("14", 4):
                    hands[i][0] = "7" + hands[i][0];
                    break;
                case ("14", 0):
                    hands[i][0] = "6" + hands[i][0];
                    break;
                case ("113", 1):
                    hands[i][0] = "6" + hands[i][0];
                    break;
                case ("113", 3):
                    hands[i][0] = "6" + hands[i][0];
                    break;
                case ("122", 2):
                    hands[i][0] = "6" + hands[i][0];
                    break;
                case ("23", 0):
                    hands[i][0] = "5" + hands[i][0];
                    break;
                case ("122", 1):
                    hands[i][0] = "5" + hands[i][0];
                    break;
                case ("113", 0):
                    hands[i][0] = "4" + hands[i][0];
                    break;
                case ("1112", 1):
                    hands[i][0] = "4" + hands[i][0];
                    break;
                case ("1112", 2):
                    hands[i][0] = "4" + hands[i][0];
                    break;
                case ("122", 0):
                    hands[i][0] = "3" + hands[i][0];
                    break;
                case ("1112", 0):
                    hands[i][0] = "2" + hands[i][0];
                    break;
                case ("11111", 1):
                    hands[i][0] = "2" + hands[i][0];
                    break;
                case ("11111", 0):
                    hands[i][0] = "1" + hands[i][0];
                    break;
                default:
                    Console.WriteLine("No match found for handnr {0}", i);
                    break;
            }

            hands[i][0] = hands[i][0]
                            .Replace('A','F')
                            .Replace('K','E')
                            .Replace('Q','D')
                            .Replace('J','0')
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
