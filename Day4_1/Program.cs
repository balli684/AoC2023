using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "../../../Input.txt";

        string[] input = File.ReadAllLines(filePath);
        
        int count = 0;

        foreach (string line in input)
        {
            var splitCard = line.Trim().Split(':');
            var splitNumbers = splitCard[1].Trim().Split('|');
            string[] winningStr = splitNumbers[0].Trim().Split(' ');
            string[] resultsStr = splitNumbers[1].Trim().Split(' ');

            winningStr = winningStr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            resultsStr = resultsStr.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int card = 0;

            foreach (string result in resultsStr)
            {
                if (winningStr.Contains(result))
                {
                    if (card == 0)
                    {
                        card++;
                    }
                    else
                    {
                        card *= 2;
                    }
                }
            }
            
            count += card;
            
        }
        Console.WriteLine(count);
    }    

}
