using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "../../../Input.txt";

        string[] input = File.ReadAllLines(filePath);
        
        int count = 0;

        int[] cardCounter = new int[input.Length];

        for (int i = 0; i < cardCounter.Length; i++)
        {
            cardCounter[i] = 1;
        }

        for (int i = 0; i < input.Length; i++)
        {
            var splitCard = input[i].Trim().Split(':');
            var splitNumbers = splitCard[1].Trim().Split('|');
            string[] winningStr = splitNumbers[0].Trim().Split(' ');
            string[] resultsStr = splitNumbers[1].Trim().Split(' ');

            winningStr = winningStr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            resultsStr = resultsStr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int wins = 0;

            foreach (string result in resultsStr)
            {
                if (winningStr.Contains(result))
                {
                    wins++;
                }
            }
            
            for (int y = 1; y <= wins; y++)
            {
                cardCounter[i+y] += cardCounter[i];
            }
            
            count += cardCounter[i];
        }

        Console.WriteLine(count);
    }    

}
